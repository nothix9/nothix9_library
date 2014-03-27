using System;
using GroupCreator;
using NUnit.Framework;

namespace GroupMakerTest
{
    [TestFixture]
    public class GroupCoordinatorTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPartipantText_IfParticipantTextIsNullOrEmpty_ThrowArgumentException()
        {
            var groupCoordinator = new GroupCoordinator();
            groupCoordinator.SetPartipantText(string.Empty);

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetGroupText_IfGroupTextIsNullOrEmpty_ThrowArgumentException()
        {
            var groupCoordinator = new GroupCoordinator();
            groupCoordinator.SetGroupText(string.Empty);
        }


    }
}
