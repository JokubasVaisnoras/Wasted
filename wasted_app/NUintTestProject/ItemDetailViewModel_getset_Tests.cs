using NUnit.Framework;
using wasted_app;
using wasted_app.ViewModels;


namespace NUintTestProject
{
    public class ItemDetailViewModel_getset_Tests
    {
        ItemDetailViewModel _vm;
        [SetUp]
        public void Setup()
        {
             _vm = new ItemDetailViewModel();
        }

        [Test]
        public void ItemDetailViewModel_getset_test1()
        {
            _vm.ItemId = "item1";
            Assert.IsNotNull(_vm.ItemId, "Username is null after initialized with a string");
            
        }
        [Test]
        public void ItemDetailViewModel_getset_test2()
        {
            _vm.Name = "item1";
            Assert.IsNotNull(_vm.Name, "Username is null after initialized with a string");

        }
        [Test]
        public void ItemDetailViewModel_getset_matchingNumbersDouble_Test()
        {
            _vm.Price = 66.666666666666666666666666666;
            Assert.AreEqual(_vm.Price, 66.666666666666666666666666666);

        }

        [Test]
        public void ItemDetailViewModel_getset_matchingNumbersInt_Test()
        {
            _vm.Amount = 66;
            Assert.AreEqual(_vm.Amount, 66);

        }
    }
}