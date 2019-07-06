using System;
using System.Collections.Generic;
using System.Text;
using Lusonixs.Search;
using Lusonixs.Search.Finders;

namespace Lusonixs.Mocks
{
    internal class MockedSearchEngine : VsFinderBase
    {
        public override bool OpenItem(VsItem item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override List<VsItem> Refresh()
        {
            List<VsItem> items = new List<VsItem>();
            
            items.Add(new VsItem(1, "Test1", "Test.Test1", "Test1.cs", VsItemType.Class));
            items.Add(new VsItem(2, "test2", "Test.Test2", "Test2.cs", VsItemType.Class));
            items.Add(new VsItem(3, "tEsT3", "Test.Test3", "Test3.cs", VsItemType.Class));
            items.Add(new VsItem(4, "MockedItem1", "Test.MockedItem1", "MockedItem1.cs", VsItemType.Class));
            items.Add(new VsItem(5, "MockedItem2", "Test.MockedItem2", "MockedItem2.cs", VsItemType.Class));
            
            return items;
        }
    }
}
