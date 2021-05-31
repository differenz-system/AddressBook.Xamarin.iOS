using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DifferenzXamarinDemo.Models
{
    public class ObservableKeyedList<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey Key { protected set; get; }

        public ObservableKeyedList(TKey key, IEnumerable<TItem> items) : base(items)
        {
            Key = key;
        }

        public ObservableKeyedList(IGrouping<TKey, TItem> grouping) : base(grouping)
        {
            Key = grouping.Key;
        }
    }
}
