# SAEExam_Practice2

Final Exam Practice 2

Narration and Transforming Data


Available time: 

3 hours

Goal: 

Starting from this repository, complete all the tasks described below.

Submission format: 

We will spend the final hour discussing different implementations and problems. If you want additional feedback, fork the repository and share the link.

Notes:

You are expected to work with Git by committing into the starting repository. Work in your own branch and merge into main when you are finished. (You are not expected (or allowed) to push.) Git usage will affect the grade in the final exam.

You are allowed to freely use external resources (Internet, books). But communicating during the exam with other people (notably the other students taking the exam) is not allowed and can be considered cheating. 
For the practice, I highly recommended trying to solve everything on your own. Even if the 3 hours of allocated time are not enough, consider trying to solve the problems afterwards.

You are allowed to ask questions during the exam. The examiner will function as a makeshift designer and will answer design questions. Technical questions will not be answered.

Make yourself familiar with the project and codebase before writing your own code. You are expected to follow established guidelines and to reuse existing features when possible.



Tasks:

There are 5 Tasks in total for a collective 100 Points:

Context:

Your team just started on a new project and you were given the task to work on the narrative system for the game. A designer has prepared a proof of concept for you in the “TestingScene”.

Task 1: (10 Points)

Add a “Continue” button to the UI. Implement an event in the DialogDisplayer class which gets fired when the “Continue” button gets clicked.

Task 2: (10 Points)

Modify the DialogRunner script to make use of the “Continue” button. Instead of waiting a fixed amount of time between messages, the story should only continue when the user presses on the “Continue” button. 
The DialogRunner class should only reference the DialogDisplayer.
The DialogRunner class should not have any references to UI.
Using a coroutine is not strictly necessary, write it the way that makes the most sense for you.

Task 3: (20 Points)

Modify the DialogRunner to not have the story integrated in the code. 
Instead the story should be editable in the inspector, allowing a designer to modify and expand it. The designer should be able to create new characters, write new dialogue lines and write new description segments. 














Task 4: (40 Points)
The team has decided to outsource the storytelling to a 3rd party writer. As she comes from a background in the film industry, you have agreed that the scenes will be delivered as movie script excerpts. As a reference you were given multiple scenes from the movie “Joker”, the formatting from these scenes matches the formatting used by the writer.

Modify the DialogRunner to allow running a scene from a text file. Make sure to keep the same final behaviour as in the original proof of concept.

You can use the SceneLoader present in the scene and its function “GetRandomScene()” to get the text for a single scene.
Make sure to get rid of special formatting in the script when visualizing it. (Specifically: no <b> etc)
The scene should always open up with the scene title. Empty lines in the scene-scripts indicate where the player should press continue to get the new line of text.
When two characters are in a dialog, one speaker should be on the left and the other on the right. Example: if Joker and Mom are talking, Joker should be on the left and Mom should be on the right.


Task 5: (20 Points)
The art department made sprites for the different characters in the story. Now, when a specific character is talking, the white Image box should display the respective sprite.
As you don’t want to reference the sprites with the characters in the future, set up a system that allows the artists to simply “link” an image to a name. This system should be independent from which dialog is being run. Simply put: if the character talking is called “Bob” and an artist added an image for “Bob”, this image should be displayed.
You can find two example images in the “Sprites/Characters” folders, for “Joker” and “Mom” respectively.
Artists should be able to “link” an image to a name either in a ScriptableObject or in a dedicated Editor window.
