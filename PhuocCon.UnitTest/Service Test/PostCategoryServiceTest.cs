using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using PhuocCon.Data.infrastructure;
using PhuocCon.Data.Repositories;
using PhuocCon.Model.Models;
using PhuocCon.Service;
namespace PhuocCon.UnitTest.Service_Test
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mocRepository;
        private Mock<IUnitOfWork> _mocUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mocRepository = new Mock<IPostCategoryRepository>();
            _mocUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mocRepository.Object, _mocUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() { ID=1 , Name="Demo 1",Status =true},
                new PostCategory() { ID=2 , Name="Demo 2",Status =true},
                new PostCategory() { ID=3 , Name="Demo 3",Status =true}
            };
        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            // setup method
            _mocRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            // call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            // compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "Test";
            category.Alias = "test";
            category.Status = true;
            _mocRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
              {
                  p.ID = 1;
                  return p;
              });
            var result = _categoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

    }
}
