using MJKProjectsDAL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJKProjectsTests.Client.Models
{    
    public class ProjectTest
    {
        [Test]
        public void TestProjectTitleToUpper()
        {
            var project = Project.MakeProject("Nullam suscipit eleifend commodo", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam iaculis porta quam eget malesuada. Maecenas facilisis diam vel imperdiet posuere. Fusce ac libero ultrices, cursus purus non, interdum velit. Mauris tristique, erat quis accumsan sollicitudin, nibh risus scelerisque dui, et euismod orci nisi bibendum massa. Aliquam erat volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce malesuada rutrum varius. Aliquam orci dolor, viverra at sagittis id, sagittis at magna. Cras sit amet erat a metus laoreet convallis eget vel mi. Morbi nunc sem, pretium eu eros sed, sagittis pharetra turpis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam iaculis dignissim risus, id pellentesque urna aliquet non. Donec laoreet ultrices diam varius dapibus.n sem eros, porttitor id risus at, scelerisque lacinia lectus. Proin suscipit arcu sit amet felis sodales placerat. Duis consectetur elementum viverra. Pellentesque dolor felis, rutrum ut auctor sodales, tempus suscipit ante. Fusce non viverra leo. Proin lorem nisl, congue eget quam vitae, ornare vestibulum purus. Aliquam porttitor nibh nec placerat eleifend. Nullam semper auctor sapien, nec scelerisque tortor lobortis vitae.");

            Assert.AreEqual("Nullam suscipit eleifend commodo".ToUpper(), project.AllCapsTitle());
        }

        [Test]
        public void TestProjectDescriptionToShorter()
        {
            var project = Project.MakeProject("Nullam suscipit eleifend commodo", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam iaculis porta quam eget malesuada. Maecenas facilisis diam vel imperdiet posuere. Fusce ac libero ultrices, cursus purus non, interdum velit. Mauris tristique, erat quis accumsan sollicitudin, nibh risus scelerisque dui, et euismod orci nisi bibendum massa. Aliquam erat volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce malesuada rutrum varius. Aliquam orci dolor, viverra at sagittis id, sagittis at magna. Cras sit amet erat a metus laoreet convallis eget vel mi. Morbi nunc sem, pretium eu eros sed, sagittis pharetra turpis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam iaculis dignissim risus, id pellentesque urna aliquet non. Donec laoreet ultrices diam varius dapibus.n sem eros, porttitor id risus at, scelerisque lacinia lectus. Proin suscipit arcu sit amet felis sodales placerat. Duis consectetur elementum viverra. Pellentesque dolor felis, rutrum ut auctor sodales, tempus suscipit ante. Fusce non viverra leo. Proin lorem nisl, congue eget quam vitae, ornare vestibulum purus. Aliquam porttitor nibh nec placerat eleifend. Nullam semper auctor sapien, nec scelerisque tortor lobortis vitae.");

            Assert.IsTrue(project.ShortContent().Length == 200);
        }
    }
}
