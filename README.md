"# Task-Capital_Placement" 

Dot NET Task
Deadline: 24 hours to complete the task.
Figma design for the task:
https://www.figma.com/community/file/1291807396898113201/create-program-design-and
-flow
Instructions for setting up task:
1. Create a public github repo and do an initial commit of an empty project to start the task.
Name the commit as “Starting-Project”
2. Your final commit must be within 24hrs of your initial commit. Do not start the project if
you are not available for next 24hrs.
3. Once completed, submit the Github link to https://forms.gle/J4T2QHdxNtUCYx2A9
Please complete the tasks below. We would like to have a short written explanation of the
updates you made.
- Create .Net 8 web application
- Create DTOs & Models based on the Figma designs below
- Implement CRUD APIs
- Data should be stored in Azure Cosmos DB for NoSQL. You can test with your local
Cosmos DB Emulator.
- Utilize dependency injection.
- Unit test (xUnit) is “nice-to-have”
Screen 1
You are an employer and you are creating a program and the application form.
1. Use the POST method to correctly store the different types of questions we have
(Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number).
2. Use the PUT method if the user wants to edit the question after creating the application.
Screen 2
Candidate applying for the program.
1. You should provide a GET endpoint for the front-end team to render the questions based
on the question type.
2. Provide a POST endpoint for the front-end team with the payload structure so that once
the candidate submits the application, you will receive the data
