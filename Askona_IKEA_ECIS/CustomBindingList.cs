using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Askona_IKEA_ECIS
{
    public class CustomBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;
        public CustomBindingList(List<T> elements) : base(elements)
        {
        }
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirection; }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }
        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
        }
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;
            if (_sortProperty == null) return; //nothing to sort on
            if (!(Items is List<T> list)) return;
            list.Sort(Compare);
            _isSorted = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        private int Compare(T lhs, T rhs)
        {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            int result = 0;
            if (rhsValue == null && lhsValue == null)
                result = 0;
            else
            {
                if (lhsValue == null)
                    result = -1;
                else if (rhsValue == null)
                    result = 1;
                else
                    if (lhsValue is IComparable comparable)
                    result = comparable.CompareTo(rhsValue);
                else if (!lhsValue.Equals(rhsValue)) //not comparable, compare ToString
                    result = lhsValue.ToString().CompareTo(rhsValue.ToString());
            }
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }
    }
}