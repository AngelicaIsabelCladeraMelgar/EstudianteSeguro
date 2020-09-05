using System;
using ApiSeccureStudent.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace UnitTestEstudianteSeguro.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGetStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();

            //Act
            var ListaEstudiante = studentsController.GetStudents();

            //Assert
            Assert.IsNotNull(ListaEstudiante);
        }
        //Tambien se puede hacer un usiario de prueba
        //tambien en el post
    }
}
