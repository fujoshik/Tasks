using Task2._3.Trainings;

var training = new Training("Training");
training.Add(new PracticalLesson("OOP", null, null));
training.Add(new Lecture("Lecture 1", "OOP"));
training.Add(new Lecture("Lecture 2", "Design patterns"));

Console.WriteLine(training.IsPractical());

var clonedTraining = training.Clone();

