using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Askona_IKEA_ECIS
{
    public partial class Galaxy : DbContext
    {
        public Galaxy() : base("name=Galaxy")
        {
        }
        public virtual DbSet<IKEA_CATALOG> IKEA_CATALOG { get; set; }
        public virtual DbSet<IKEA_PLAN_2020> IKEA_PLAN_2020 { get; set; }
    }

    [Table("GAL_ASUP.IKEA_CATALOG")]
    public partial class IKEA_CATALOG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string STORE { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ARTNO { get; set; }
        [StringLength(100)]
        public string ARTNAME { get; set; }
        public int PAL_COUNT { get; set; }
        [StringLength(2)]
        public string PAL_TYPE { get; set; }
        public double PRICE { get; set; }
        public double VOLUME { get; set; }
    }
    public partial class IKEA_CATALOG_VIEW
    {
        [StringLength(10)]
        public string ARTNO { get; set; }
        [StringLength(100)]
        public string ARTNAME { get; set; }
        public int PAL_COUNT { get; set; }
        [StringLength(2)]
        public string PAL_TYPE { get; set; }
        public double PRICE { get; set; }
        public double VOLUME { get; set; }
    }
    [Table("GAL_ASUP.IKEA_PLAN_2020")]
    public partial class IKEA_PLAN_2020
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string STORE { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string ARTNO { get; set; }
        [StringLength(150)]
        public string ARTNAME { get; set; }
        public int STOCK_AVAILABLE { get; set; }
        public int GOODS_IN_TRANSIT { get; set; }
        public int DNMK_1 { get; set; }
        public int DNMK_2 { get; set; }
        public int DNMK_3 { get; set; }
        public int AVG_DNMK { get; set; }
        public int SALES { get; set; }
        [StringLength(10)]
        public string SERVICE_LEVEL { get; set; }
        [StringLength(8)]
        public string STARTDATE { get; set; }
        [StringLength(8)]
        public string FINISHDATE { get; set; }
        public int SUPPLY { get; set; }
        public int PLAN { get; set; }
        public int PLAN_OUT { get; set; }
        public int AVG_DNMK_FUT { get; set; }
        public int DNMK_FUT1 { get; set; }
        public int DNMK_FUT2 { get; set; }
        public int DNMK_FUT3 { get; set; }
        public int FSALDOKOL { get; set; }
        public int FPZKOL { get; set; }
        public int FPZKOL_FUT { get; set; }
        public int MINIMUM { get; set; }
        public int MAXIMUM { get; set; }
        public int PLAN_ORDER_QNTY { get; set; }
    }

    public class IKEA_PLAN_VIEW
    {
        [StringLength(3)]
        public string STORE { get; set; }
        [StringLength(8)]
        public string ARTNO { get; set; }
        [StringLength(150)]
        public string ARTNAME { get; set; }
        public int DNMK_1 { get; set; }
        public int DNMK_2 { get; set; }
        public int DNMK_3 { get; set; }
        public int AVG_DNMK { get; set; }
        public int DNMK_FUT1 { get; set; }
        public int DNMK_FUT2 { get; set; }
        public int DNMK_FUT3 { get; set; }
        public int AVG_DNMK_FUT { get; set; }
        public int SALES { get; set; }
        public int PLAN_ORDER_QNTY { get; set; }
        public int STOCK_AVAILABLE { get; set; }
        public int SUPPLY { get; set; }
        public int GOODS_IN_TRANSIT { get; set; }
        public int PLAN_OUT { get; set; }
        public int MINIMUM { get; set; }
        public double AVG_MAX { get; set; }
        public int MAXIMUM { get; set; }
        public int PLAN { get; set; }
        public double DELTA { get; set; }
        [StringLength(10)]
        public string SERVICE_LEVEL { get; set; }
        public int FSALDOKOL { get; set; }
        public int FPZKOL { get; set; }
        public int FPZKOL_FUT { get; set; }
        [StringLength(8)]
        public string STARTDATE { get; set; }
        [StringLength(8)]
        public string FINISHDATE { get; set; }
    }
}