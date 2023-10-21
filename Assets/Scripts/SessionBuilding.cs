using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public partial class Session : MonoBehaviour
{
    private void BuildQuestionaire()
    {
        StartAdding();

        allQuestions.Add(new Question(Qtype.start, ""));

        allQuestions.Add(new Question(Qtype.names, "Please put all your names in here, one at a time:"));

        allQuestions.Add(
            new Question(Qtype.rank, "Which group member has the longest reach?")
            .withFollowUp(new Question(Qtype.single, "Has !PFIRST played basketball?"), instant: false));
        allQuestions.Add(
            new Question(Qtype.rank, "Who is best suited to handle small animals?")
            .withFollowUp(new Question(Qtype.single, "!PFIRST, Do you try to save worms that are crossing the street?"), instant: false)
            .withArduinoEvt(new Shake()));
        CreateDiv();
        allQuestions.Add(
            new Question(Qtype.rank, "Who is the most hygienic?")
            .withFollowUp(new Question(Qtype.single, "!PFIRST, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, !PLAST, could enhance their hygiene practices."), instant: false));
        allQuestions.Add(
            new Question(Qtype.rank, "Which person in the group is most likely to pick up a hitchhiker?")
            .withFollowUp(new Question(Qtype.single, "!PFIRST, do you like movies about gladiators?"), instant: false));
        allQuestions.Add(
            new Question(Qtype.rank, "Who is the most law-abiding?")
            .withFollowUp(new Question(Qtype.single, "Has !PLAST ever broken the law?"), instant: false)
            .withArduinoEvt(new Shake())
            );

        CreateDiv();

        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));

        allQuestions.Add(new Question(Qtype.rank, "Who has the highest pain threshold?").withFollowUp
            (new Question(Qtype.single, "Do you dare to put your hand in the box?"), instant: true)
            .withMusicEvt(new RemoveHighPass()));

        allQuestions.Add(new Question(Qtype.rank, "Who has the most knowledge in the fantasy genre of fiction?")
            .withFollowUp(
            new Question(Qtype.single, "Share reading tips"), instant: true)
            .withMusicEvt(new AddDistortion()));

        allQuestions.Add(new Question(Qtype.rank, "Who is most interested in true-crime?")
            .withFollowUp(new Question(Qtype.single, "!PFIRST, Why do you like it?"), instant: false));
        allQuestions.Add(new Question(Qtype.rank, "Who would enjoy being a mole for a day?")
            .withFollowUp(new Question(Qtype.single, "Did you mean the animal or?"), instant: false));
        allQuestions.Add(new Question(Qtype.rank, "Is there anyone in the group that does not believe computers are conscious?")
            .withFollowUp(new Question(Qtype.single, "Do you believe i pass the turing test?"), instant: false));

        CreateDiv();

        currentQuestion = GetComponent<Blank>();
        currentQuestion.Rebuild(new Question(Qtype.divider, ""));
        currentQuestion.finished = true;

    }



    private void CreateDiv()
    {
        allQuestions.Add(new Question(Qtype.divider, ""));
    }

    private void StartAdding()
    {
        allQuestions.Add(new Question(Qtype.divider, ""));

    }

}
