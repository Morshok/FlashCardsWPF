# FlashCardsWPF - A Flashcards Application
A Flashcards Application made in Visual Studio 2022 using C# and an SQLite Database backend.
### Table of Contents
- [General Info](#general-info)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [How To Use The Application](#how-to-use-the-application)

___

### General Info:
The application was made using C# and features an SQLite Database backend, which is a fast and small embedded database.
The purpose of the creation of the application was to facilitate studying before an exam, which quickly became a larger than expected project.
With the application you can create, update and study created flashcards. In the future, spaced repetition will perhaps be supported as well.

___

### Technologies Used:
This project utilizes the following technologies:
- SQLite Database
- Windows Presentation Foundation

___

### Setup:
To be added once the application is ready for release

___

### How To Use The Application:

When first running the application, you will be presented with a page that looks like the following:
![Main Page](https://github.com/Morshok/readme-images/blob/master/FlashcardsWPF/WelcomePage.png)<br>
To quit the application, simply hit Quit Application. Otherwise, you can create, update and study your created flashcards by clicking the corresponding buttons.

This is the page you are presented with when clicking ***Create New Flashcard***:
![Create New Flashcard Page](https://github.com/Morshok/readme-images/blob/master/FlashcardsWPF/CreateNewFlashcardPage.png)<br>
Put simply, just fill in all the information required by the form to create your own flashcards.

This is the page you are presented with when clicking ***Update Flashcards***:
![Update Flashcard Page](https://github.com/Morshok/readme-images/blob/master/FlashcardsWPF/UpdateFlashcardPage.png)<br>
For the moment being, only deleting an entire topic or deleting a question from a topic is currently supported bu this page. Subsequently, if you were to delete the last question of a specific topic, that topic would also be deleted from the database. In the future, updating information regarding individual questions will also be supported.

This is the page you are presented with when clicking ***Study Flashcards***:
![Study Flashcard Page Question](https://github.com/Morshok/readme-images/blob/master/FlashcardsWPF/StudyFlashcardPage_Question.png)<br>
As can be seen, simply select the topic of flashcards you want to study and keep on studying! To change questions simply hit the forwards and backwards buttons. In order to check for the right answer, simply click on the flashcard with your left mouse button and the answer will be revealed upon releasing the mouse button, as can be seen in the image below:
![Study Flashcard Page Answer](https://github.com/Morshok/readme-images/blob/master/FlashcardsWPF/StudyFlashcardPage_Answer.png)

As a final note, multiple choices flashcards are intended to be implemented together with the spaced repetition in the future.
___
