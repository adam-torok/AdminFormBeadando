using NUnit.Framework;
using AdminForm.Presenters;
using AdminForm.Interfaces;
using AdminForm.Models;
using System.ComponentModel;
using AdminForm.Repositories;
using System;

namespace UnitTests
{
    class FakeUser : IUser
    {
        public felhasznalo felhasznalo { get; set; }
        public BindingList<felhasznalo> felhlist { get; set; }
        public string errorMsg { get; set; }

        public FakeUser(felhasznalo _felhasznalo, BindingList<felhasznalo> _felhasznalok, string _errorMesage)
        {
            felhasznalo = _felhasznalo;
            felhlist = _felhasznalok;
            errorMsg = _errorMesage;
        }
    }

    class FakeUserRepo : IUserRepo
    {
        public const string UPDATE_ERROR_MESSAGE = "UPDATE_ERROR_MESSAGE";

        private bool _existsResult;
        private bool _shouldThrowExceptionOnUpdate;

        public bool wasUpdateCalled = false;

        public FakeUserRepo(bool existsResult = false, bool shouldThrowExceptionOnUpdate = false)
        {
            _existsResult = existsResult;
            _shouldThrowExceptionOnUpdate = shouldThrowExceptionOnUpdate;
        }

        public int Count() => 0;

        public void Delete(int id) { }

        public void Dispose() { }

        public bool Exists(felhasznalo user) => _existsResult;

        public BindingList<felhasznalo> getAllUser(int page = 0, int itemsPerPage = 0, string search = null, string sortBy = null, bool ascending = true)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(felhasznalo user) { }

        public void Save() { }

        public void Update(felhasznalo user) {
            wasUpdateCalled = true;
            if (_shouldThrowExceptionOnUpdate)
            {
                throw new Exception(message: UPDATE_ERROR_MESSAGE);
            }
        }
    }

    public class UserPresenterTest
    {
         

        [SetUp]
        public void Setup()
        {
            // TODO
        }

        [Test]
        public void SaveShouldSetErrorMessageToNull()
        {
            // Arrange
            IUser fakeUser = new FakeUser(new felhasznalo(), new BindingList<felhasznalo>(), "testError");
            IUserRepo fakeUserRepo = new FakeUserRepo();
            UserPresenter userPresenter = new UserPresenter(fakeUser, fakeUserRepo);

            // Act
            userPresenter.Save(new felhasznalo());

            // Assert
            Assert.IsNull(fakeUser.errorMsg);
        }

        [Test]
        public void GivenTheUserExistsInTheRepo_WhenWeSaveTheUser_ThenWeShouldUpdateTheUser()
        {
            // Arrange
            FakeUser fakeUser = new FakeUser(new felhasznalo(), new BindingList<felhasznalo>(), "testError");
            FakeUserRepo fakeUserRepo = new FakeUserRepo(existsResult: true);
            UserPresenter userPresenter = new UserPresenter(fakeUser, fakeUserRepo);

            // Act
            userPresenter.Save(new felhasznalo());

            // Assert
            Assert.IsTrue(fakeUserRepo.wasUpdateCalled);
        }

        [Test]
        public void GivenTheUserExistsButTheRepoCantUpdateIt_WhenWeSaveTheUser_ThenTheErrorMessageFieldShouldBeSetToUpdateError()
        {
            // Arrange
            FakeUser fakeUser = new FakeUser(new felhasznalo(), new BindingList<felhasznalo>(), "testError");
            FakeUserRepo fakeUserRepo = new FakeUserRepo(existsResult: true, shouldThrowExceptionOnUpdate: true);
            UserPresenter userPresenter = new UserPresenter(fakeUser, fakeUserRepo);

            // Act
            userPresenter.Save(new felhasznalo());

            // Assert
            Assert.AreEqual(FakeUserRepo.UPDATE_ERROR_MESSAGE, fakeUser.errorMsg);
        }
    }
}