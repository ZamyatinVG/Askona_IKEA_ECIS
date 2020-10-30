create or replace package IKEA is

  function to_ikeadate(p_str in varchar2) return date deterministic;
  procedure CALCULATE_2020(startdate varchar2, finishdate varchar2, p_store varchar2, p_mark numeric);
  procedure TransferData_2020;
  procedure TransferSupply_2020;

end IKEA;
/
create or replace package body IKEA is

  function to_ikeadate(p_str in varchar2) return date DETERMINISTIC is
  begin
    return TO_DATE(p_str, 'YYYYMMDD', 'NLS_DATE_LANGUAGE = AMERICAN');
  end to_ikeadate;
  
  procedure CALCULATE_2020(startdate varchar2, finishdate varchar2, p_store varchar2, p_mark numeric) is
  --неделя начинается с Вс
    v_count number;
  begin
    if (p_store != 'ALL') then 
      delete from gal_asup.ikea_plan_2020 p 
        where p.store = p_store;
    else 
      delete from gal_asup.ikea_plan_2020;
    end if;
    commit;
    delete from gal_asup.ikea_saldo;
    if (p_mark = 1) then
      insert into gal_asup.ikea_saldo(artno, fsaldo)
        select artno, sum(kol) kol from
          (select replace(substr(k.fbarkod, 1, 10), '-', '') artno,
                       round(sldmc.fkol) kol
                from gal_vek.saldomc sldmc,
                     gal_vek.katmc k
                where sldmc.fdsaldo = (select max(saldomc_last.fdsaldo)
                                         from gal_vek.saldomc saldomc_last
                                         where saldomc_last.fcmc = sldmc.fcmc
                                         and saldomc_last.fcpodr  = sldmc.fcpodr
                                         and saldomc_last.fcmol = sldmc.fcmol
                                         and saldomc_last.fdsaldo <= gal_vek.to_atldate(to_ikeadate(startdate)))                    
                and sldmc.fkol <> 0
                and sldmc.fcmc = k.fnrec
                and sldmc.fcpodr = '8001000000024986'
                and sldmc.fcmol in '8001000000000721'
                and k.fname$up like 'МАТРАС%'
          union all
          select replace(substr(k.fbarkod, 1, 10), '-', '') artno,
                       round(sldmc.fkol) kol
                from gal_vek.saldomc sldmc,
                     gal_vek.katmc k
                where sldmc.fdsaldo = (select max(saldomc_last.fdsaldo)
                                         from gal_vek.saldomc saldomc_last
                                         where saldomc_last.fcmc = sldmc.fcmc
                                         and saldomc_last.fcpodr  = sldmc.fcpodr
                                         and saldomc_last.fcmol = sldmc.fcmol
                                         and saldomc_last.fdsaldo <= gal_vek.to_atldate(to_ikeadate(startdate)))                    
                and sldmc.fkol <> 0
                and sldmc.fcmc = k.fnrec
                and sldmc.fcpodr = '8001000000024984'
                and sldmc.fcmol in '800100000000071F'
                and k.fname$up like 'МАТРАС%')
          group by artno;
      for i in (select artno, sum(pzkol) pzkol, sum(pzkol_fut) pzkol_fut from
                  (select replace(substr(k.fbarkod, 1, 10), '-', '') artno, round(vsm.fprice) pzkol, 0 pzkol_fut
                  from gal_vek.mnplan mp,
                       gal_vek.spmnplan smp,
                       gal_vek.spmnpl mnpl,
                       gal_vek.valspmnp vsm,
                       gal_vek.katmc k
                  where mp.ftypeplan = 17
                  and mp.fname like '%Матрасы ИКЕА для снабжения%'
                  and mp.futvdate = gal_vek.to_atldate(to_ikeadate(startdate))
                  and smp.fcmnplan = mp.fnrec
                  and mp.fnrec = mnpl.fcmnplan
                  and smp.fnrec = mnpl.fcspmnplan
                  and mnpl.fnrec = vsm.fcspmnpl
                  and smp.fcizd = k.fnrec
                  and k.fname$up like 'МАТРАС%'
                  union all
                  select replace(substr(k.fbarkod, 1, 10), '-', '') artno, 0 pzkol, sum(round(vsm.fprice)) pzkol_fut
                  from gal_vek.mnplan mp,
                       gal_vek.spmnplan smp,
                       gal_vek.spmnpl mnpl,
                       gal_vek.valspmnp vsm,
                       gal_vek.katmc k
                  where mp.ftypeplan = 17
                  and mp.fname like '%Матрасы ИКЕА для снабжения%'
                  and mp.futvdate between gal_vek.to_atldate(to_ikeadate(startdate)+1) and gal_vek.to_atldate(to_ikeadate(finishdate))
                  and smp.fcmnplan = mp.fnrec
                  and mp.fnrec = mnpl.fcmnplan
                  and smp.fnrec = mnpl.fcspmnplan
                  and mnpl.fnrec = vsm.fcspmnpl
                  and smp.fcizd = k.fnrec
                  and k.fname$up like 'МАТРАС%'
                  group by k.fbarkod)
                  group by artno)
      loop
        select count(*) into v_count
          from gal_asup.ikea_saldo s
          where s.artno = i.artno;
        if (v_count <> 0) then  
          update gal_asup.ikea_saldo s
            set s.fpzkol = i.pzkol,
                s.fpzkol_fut = i.pzkol_fut
            where s.artno = i.artno;
        else
          insert into gal_asup.ikea_saldo(artno, fsaldo, fpzkol, fpzkol_fut)
            values(i.artno, 0, i.pzkol, i.pzkol_fut);
        end if;      
      end loop; 
    end if;  
    insert into gal_asup.ikea_plan_2020
      select it.ikea_store_customer store,
             it.ikea_item_number artno,
             ic.artname artname,
             round(nvl(it.available_stock, 0)) stock_available,
             round(it5.quantity_in_transit) goods_in_transit,
             round(nvl(sup1.sales_count, 0)) dnmk_1,
             round(nvl(sup2.sales_count, 0)) dnmk_2, 
             round(nvl(sup3.sales_count, 0)) dnmk_3,
             0 avg_dnmk,
             0 sales, 
             nvl(it.service_level, 0) service_level,
             startdate startdate, 
             finishdate finishdate,
             nvl(sopr.qnty, 0) supply,
             round(nvl(it.available_stock, 0) + nvl(sopr.qnty, 0) + it5.quantity_in_transit - (nvl(it1.sales_quantity_planned, 0) + nvl(it1.sales_quantity_planned, 0) + nvl(it1.sales_quantity_planned, 0)) / 3) plan,
             round(nvl(it.available_stock, 0) + nvl(sopr.qnty, 0) + it5.quantity_in_transit) plan_out,
             round((nvl(it1.sales_quantity_planned, 0) + nvl(it2.sales_quantity_planned, 0) + nvl(it3.sales_quantity_planned, 0)) / 3) avg_dnmk_fut,
             round(nvl(it1.sales_quantity_planned, 0)) dnmk_fut1,
             round(nvl(it2.sales_quantity_planned, 0)) dnmk_fut2,
             round(nvl(it3.sales_quantity_planned, 0)) dnmk_fut3,
             nvl(saldo.fsaldo, 0) fsaldokol,
             nvl(saldo.fpzkol, 0) fpzkol,
             nvl(saldo.fpzkol_fut, 0) fpzkol_fut,
             round(it.safety_stock) minimum,
             round(it.maximum_stock) maximum,
             round(nvl(it4.planned_order_quantity, 0)) plan_order_qnty
        from gal_asup.ikea_tranzact_2020 it
        join gal_asup.ikea_catalog ic on it.ikea_store_customer = ic.store and it.ikea_item_number = ic.artno
        left join (select replace(mc.fbarkod, '-', '') artno, av.fvstring store, round(sum(ss.fkolfact)) qnty
                    from gal_vek.katsopr ks
                    join gal_vek.spsopr ss on ks.fnrec = ss.fcsopr
                    join gal_vek.katmc mc on ss.fcmcusl = mc.fnrec
                    join gal_vek.attrval av on ks.fnrec = av.fcrec and av.fcattrnam = '800100000009F4F6' and av.fwtable = 1109
                    where ks.fatl_branch = '8000000000000006'
                    and ks.fvidsopr = 201
                    and ks.fcorg = '800B0000000009DB' --'ООО "ИКЕА ТОРГ"'
                    and to_char(gal_vek.to_oradate(ks.fdsopr), 'YYYYMMDD') between startdate and finishdate 
                    group by replace(mc.fbarkod, '-', ''), av.fvstring) sopr on it.ikea_item_number = sopr.artno and it.ikea_store_customer = sopr.store
        left join gal_asup.ikea_saldo saldo on it.ikea_item_number = saldo.artno
        left join (select it1.ikea_store_customer, it1.ikea_item_number, sum(it1.sales_quantity_planned) sales_quantity_planned
                     from gal_asup.ikea_tranzact_2020 it1
                     where it1.start_date_of_forecast_period >= to_char(to_date(startdate, 'YYYYMMDD') + 7 - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7), 'YYYYMMDD')
                     and it1.start_date_of_forecast_period < to_char(to_date(startdate, 'YYYYMMDD') + 7 - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7) + 7, 'YYYYMMDD')
                     group by it1.ikea_store_customer, it1.ikea_item_number
                  ) it1 on it.ikea_store_customer = it1.ikea_store_customer and it.ikea_item_number = it1.ikea_item_number
        left join (select it2.ikea_store_customer, it2.ikea_item_number, sum(it2.sales_quantity_planned) sales_quantity_planned
                     from gal_asup.ikea_tranzact_2020 it2
                     where it2.start_date_of_forecast_period >= to_char(to_date(startdate, 'YYYYMMDD') + 14 - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7), 'YYYYMMDD')
                     and it2.start_date_of_forecast_period < to_char(to_date(startdate, 'YYYYMMDD') + 14 - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7) + 7, 'YYYYMMDD')
                     group by it2.ikea_store_customer, it2.ikea_item_number
                  ) it2 on it.ikea_store_customer = it2.ikea_store_customer and it.ikea_item_number = it2.ikea_item_number
        left join (select it3.ikea_store_customer, it3.ikea_item_number, sum(it3.sales_quantity_planned) sales_quantity_planned
                     from gal_asup.ikea_tranzact_2020 it3
                     where it3.start_date_of_forecast_period >= to_char(to_date(startdate, 'YYYYMMDD') + 21 - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7), 'YYYYMMDD')
                     and it3.start_date_of_forecast_period < to_char(to_date(startdate, 'YYYYMMDD') + 21 - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7) + 7, 'YYYYMMDD')
                     group by it3.ikea_store_customer, it3.ikea_item_number
                  ) it3 on it.ikea_store_customer = it3.ikea_store_customer and it.ikea_item_number = it3.ikea_item_number
        left join (select it4.ikea_store_customer, it4.ikea_item_number, sum(it4.planned_order_quantity) planned_order_quantity
                     from gal_asup.ikea_tranzact_2020 it4
                     where it4.start_date_of_forecast_period >= startdate
                     and it4.start_date_of_forecast_period < to_char(to_date(startdate, 'YYYYMMDD') - mod(to_number(to_char(to_date(startdate, 'YYYYMMDD'), 'D')), 7) + 7, 'YYYYMMDD')
                     group by it4.ikea_store_customer, it4.ikea_item_number
                  ) it4 on it.ikea_store_customer = it4.ikea_store_customer and it.ikea_item_number = it4.ikea_item_number
        left join (select it5.ikea_store_customer, it5.ikea_item_number, sum(it5.quantity_in_transit) quantity_in_transit
                     from gal_asup.ikea_tranzact_2020 it5
                     where it5.start_date_of_forecast_period >= startdate
                     and it5.start_date_of_forecast_period < to_char(to_date(startdate, 'YYYYMMDD') + 30, 'YYYYMMDD')
                     group by it5.ikea_store_customer, it5.ikea_item_number
                  ) it5 on it.ikea_store_customer = it5.ikea_store_customer and it.ikea_item_number = it5.ikea_item_number
        left join gal_asup.ikea_supply_2020 sup1 on it.ikea_store_customer = sup1.store_number
                                                and it.ikea_item_number = sup1.item_number
                                                and sup1.week_number = to_char(to_ikeadate(it.start_date_of_forecast_period) - 7, 'YYYYIW')
        left join gal_asup.ikea_supply_2020 sup2 on it.ikea_store_customer = sup2.store_number
                                                and it.ikea_item_number = sup2.item_number
                                                and sup2.week_number = to_char(to_ikeadate(it.start_date_of_forecast_period) - 14, 'YYYYIW')
        left join gal_asup.ikea_supply_2020 sup3 on it.ikea_store_customer = sup3.store_number
                                                and it.ikea_item_number = sup3.item_number
                                                and sup3.week_number = to_char(to_ikeadate(it.start_date_of_forecast_period) - 21, 'YYYYIW')
        where it.start_date_of_forecast_period = startdate 
        and (it.ikea_store_customer = p_store or p_store = 'ALL');
  end CALCULATE_2020;
   
  procedure TransferData_2020 is
  begin
    merge into gal_asup.ikea_tranzact_2020 m
      using gal_asup.ikea_tranzact_2020_temp t
      on (m.start_date_of_forecast_period = t.start_date_of_forecast_period and m.ikea_item_number = t.ikea_item_number and m.ikea_store_customer = substr(t.ikea_store_customer, 1, 3))
      when matched then update set m.generated_on = t.generated_on,
                                   m.name_of_document = t.name_of_document,
                                   m.ikea_supplier_number = t.ikea_supplier_number,
                                   m.receiving_address_sequence = t.receiving_address_sequence,
                                   m.first_transition_location = t.first_transition_location,
                                   m.line_number = t.line_number,
                                   m.ikea_item_name = t.ikea_item_name,
                                   m.from_date = t.from_date,
                                   m.to_date = t.to_date,
                                   m.sales_method = t.sales_method,
                                   m.service_level = t.service_level,
                                   m.planned_order_quantity = to_number(replace(t.planned_order_quantity, '.', ',')),
                                   m.quantity_in_transit = to_number(replace(t.quantity_in_transit, '.', ',')),
                                   m.quality_or_license_issue = to_number(replace(t.quality_or_license_issue, '.', ',')),
                                   m.safety_stock = to_number(replace(t.safety_stock, '.', ',')),
                                   m.maximum_stock = to_number(replace(t.maximum_stock, '.', ',')),
                                   m.quantity_planned_for_delivery = to_number(replace(t.quantity_planned_for_delivery, '.', ',')),
                                   m.available_stock = to_number(replace(t.available_stock, '.', ',')),
                                   m.sales_quantity_planned = to_number(replace(t.sales_quantity_planned, '.', ',')),
                                   m.filename = t.filename
      when not matched then insert values(t.generated_on, 
                                         t.name_of_document, 
                                         t.ikea_supplier_number, 
                                         substr(t.ikea_store_customer, 1, 3), 
                                         t.receiving_address_sequence, 
                                         t.first_transition_location,
                                         t.start_date_of_forecast_period,
                                         t.end_date_of_forecast_period,
                                         t.line_number, 
                                         t.ikea_item_number, 
                                         t.ikea_item_name, 
                                         t.from_date, 
                                         t.to_date, 
                                         t.sales_method,
                                         t.service_level,
                                         to_number(replace(t.planned_order_quantity, '.', ',')), 
                                         to_number(replace(t.quantity_in_transit, '.', ',')), 
                                         to_number(replace(t.quality_or_license_issue, '.', ',')), 
                                         to_number(replace(t.safety_stock, '.', ',')), 
                                         to_number(replace(t.maximum_stock, '.', ',')), 
                                         to_number(replace(t.quantity_planned_for_delivery, '.', ',')), 
                                         to_number(replace(t.available_stock, '.', ',')), 
                                         to_number(replace(t.sales_quantity_planned, '.', ',')), 
                                         t.filename); 
    delete from gal_asup.ikea_tranzact_2020_temp;  
  exception
    when others then
      begin
        --костыль для американской кодировки
        merge into gal_asup.ikea_tranzact_2020 m
          using gal_asup.ikea_tranzact_2020_temp t
          on (m.start_date_of_forecast_period = t.start_date_of_forecast_period and m.ikea_item_number = t.ikea_item_number and m.ikea_store_customer = substr(t.ikea_store_customer, 1, 3))
          when matched then update set m.generated_on = t.generated_on,
                                       m.name_of_document = t.name_of_document,
                                       m.ikea_supplier_number = t.ikea_supplier_number,
                                       m.receiving_address_sequence = t.receiving_address_sequence,
                                       m.first_transition_location = t.first_transition_location,
                                       m.line_number = t.line_number,
                                       m.ikea_item_name = t.ikea_item_name,
                                       m.from_date = t.from_date,
                                       m.to_date = t.to_date,
                                       m.sales_method = t.sales_method,
                                       m.service_level = t.service_level,
                                       m.planned_order_quantity = to_number(t.planned_order_quantity),
                                       m.quantity_in_transit = to_number(t.quantity_in_transit),
                                       m.quality_or_license_issue = to_number(t.quality_or_license_issue),
                                       m.safety_stock = to_number(t.safety_stock),
                                       m.maximum_stock = to_number(t.maximum_stock),
                                       m.quantity_planned_for_delivery = to_number(t.quantity_planned_for_delivery),
                                       m.available_stock = to_number(t.available_stock),
                                       m.sales_quantity_planned = to_number(t.sales_quantity_planned),
                                       m.filename = t.filename
          when not matched then insert values(t.generated_on, 
                                             t.name_of_document, 
                                             t.ikea_supplier_number, 
                                             substr(t.ikea_store_customer, 1, 3), 
                                             t.receiving_address_sequence, 
                                             t.first_transition_location,
                                             t.start_date_of_forecast_period,
                                             t.end_date_of_forecast_period,
                                             t.line_number, 
                                             t.ikea_item_number, 
                                             t.ikea_item_name, 
                                             t.from_date, 
                                             t.to_date, 
                                             t.sales_method,
                                             t.service_level,
                                             to_number(t.planned_order_quantity), 
                                             to_number(t.quantity_in_transit), 
                                             to_number(t.quality_or_license_issue), 
                                             to_number(t.safety_stock), 
                                             to_number(t.maximum_stock), 
                                             to_number(t.quantity_planned_for_delivery), 
                                             to_number(t.available_stock), 
                                             to_number(t.sales_quantity_planned), 
                                             t.filename);
      exception
        when others then
          null;
      end;
    delete from gal_asup.ikea_tranzact_2020_temp;  
  end TransferData_2020;
  
  procedure TransferSupply_2020 is
    v_header gal_asup.ikea_supply_2020_temp%ROWTYPE;
  begin
    select t.* into v_header
      from gal_asup.ikea_supply_2020_temp t
      where t.t1 = 'Art No.';
    merge into gal_asup.ikea_supply_2020 sup
      using (select *
               from gal_asup.ikea_supply_2020_temp t
               where nvl(t.t6, ' ') not in (' ', 'EURU', 'Rec Code')
               and t.t16 <> 0
            ) t
      on (sup.store_number = t.t6 and sup.item_number = t.t1 and sup.week_number = v_header.t16)
      when matched then update set sup.sales_count = t.t16 where sup.sales_count <> t.t16
      when not matched then insert values (t.t6, t.t1, v_header.t16, t.t16);
    merge into gal_asup.ikea_supply_2020 sup
      using (select *
               from gal_asup.ikea_supply_2020_temp t
               where nvl(t.t6, ' ') not in (' ', 'EURU', 'Rec Code')
               and t.t17 <> 0
            ) t
      on (sup.store_number = t.t6 and sup.item_number = t.t1 and sup.week_number = v_header.t17)
      when matched then update set sup.sales_count = t.t17 where sup.sales_count <> t.t17
      when not matched then insert values (t.t6, t.t1, v_header.t17, t.t17);
    merge into gal_asup.ikea_supply_2020 sup
      using (select *
               from gal_asup.ikea_supply_2020_temp t
               where nvl(t.t6, ' ') not in (' ', 'EURU', 'Rec Code')
               and t.t18 <> 0
            ) t
      on (sup.store_number = t.t6 and sup.item_number = t.t1 and sup.week_number = v_header.t18)
      when matched then update set sup.sales_count = t.t18 where sup.sales_count <> t.t18
      when not matched then insert values (t.t6, t.t1, v_header.t18, t.t18);
    merge into gal_asup.ikea_supply_2020 sup
      using (select *
               from gal_asup.ikea_supply_2020_temp t
               where nvl(t.t6, ' ') not in (' ', 'EURU', 'Rec Code')
               and t.t19 <> 0
            ) t
      on (sup.store_number = t.t6 and sup.item_number = t.t1 and sup.week_number = v_header.t19)
      when matched then update set sup.sales_count = t.t19 where sup.sales_count <> t.t19
      when not matched then insert values (t.t6, t.t1, v_header.t19, t.t19);
    delete from gal_asup.ikea_supply_2020_temp;
  end TransferSupply_2020;
  
end IKEA;
/
