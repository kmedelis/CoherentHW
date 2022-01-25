using TrainingManagmentSystem;

Training training = new Training();
PracticalLesson practical = new PracticalLesson();
Lecture lecture = new Lecture();


training.add(practical); // adds practical to training1

Training training2 = training.Clone(); // creates training2 which should contain one practical from cloning

Console.WriteLine(training.isPractical()); // checkes whether trainings have only practicals (returns true)
Console.WriteLine(training2.isPractical());

training.add(lecture); //add lecture to training1 only
Console.WriteLine(training.isPractical()); // this returns false because training1 has lecture
Console.WriteLine(training2.isPractical()); // this returns true because training2 only has practicals