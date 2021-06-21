using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Models;

namespace WebApplicationTests
{
    //Test my implementation of methods - easier here than in launched app

    [TestClass]
    public class PhotoGalleryViewModelTest
    {
        [TestMethod]
        public void GetTagsFromPhotoTest()
        {
            //Arrange
            PhotoItemViewModel photo = new PhotoItemViewModel { Title = "test", Tags = "Tatry, Rysy Nizne" };
            PhotoGalleryViewModel photoGalleryViewModel = new PhotoGalleryViewModel();

            //Act
            string[] actual = photoGalleryViewModel.GetTagsFromPhoto(photo);

            //Assert
            Assert.AreEqual("Tatry", actual[0]);
            Assert.AreEqual("Rysy Nizne", actual[1]);
        }

        [TestMethod]
        public void GetAllUniqueTags()
        {
            //Arrange
            PhotoItemViewModel photo1 = new PhotoItemViewModel { Title = "test", Tags = "Tatry, Rysy Nizne" };
            PhotoItemViewModel photo2 = new PhotoItemViewModel { Title = "test", Tags = "Tatry, Swinica" };
            PhotoItemViewModel photo3 = new PhotoItemViewModel { Title = "test", Tags = "Tatry, Granaty" };
            PhotoGalleryViewModel photoGalleryViewModel = new PhotoGalleryViewModel();
            photoGalleryViewModel.Photos = new PhotoItemViewModel[3] { photo1, photo2, photo3 };

            //Act
            string[] actual = photoGalleryViewModel.GetAllUniqueTags();

            //Assert
            Assert.AreEqual("Tatry", actual[0]);
            Assert.AreEqual("Rysy Nizne", actual[1]);
            Assert.AreEqual("Swinica", actual[2]);
            Assert.AreEqual("Granaty", actual[3]);
        }
    }
}
