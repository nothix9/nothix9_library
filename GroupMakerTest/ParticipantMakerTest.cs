using System.Collections.Generic;
using System.Text;
using GroupCreator;
using NUnit.Framework;

namespace GroupMakerTest
{
    [TestFixture]
    public class ParticipantMakerTest
    {
        [Test]
        public void ParseToParticipant_WhenThereAreFourLinesOfString_ThereShouldBeFourLine()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Participant1");
            sb.AppendLine("Participant2");
            sb.AppendLine("Participant3");
            sb.Append("Participant4");


            var participantMaker = new ParticipantMaker();
            IList<Participant> participants = participantMaker.ParseParticipants(sb.ToString());



            Assert.That(participants.Count, Is.EqualTo(4));
        }
    }
}