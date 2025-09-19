# DigitalEmotionDiary
 **Digital Emotion Diary** is a C#/.NET commend-line diary application that enables users to publish, manage, and explore with diary entries. Users can view public entries from other app users while maintaining control over their private entries. Developed as part of a Software Design course at Kristiania University College.

## Key Features
### 1. Emotion and Background Color
Each entry is tagged with a mood and associated color.
For example:
- Happy mood– `Yellow`
- Energized– `Orange`
- Stressed– `Red`
- Annoyed– `Black`
 
### 2. Likes and Comments
Engage with entries through reactions and comments.
 
### 3. Tags and Filtering
Organize and filter entries by mood or tags.
 
### 4. Command-Line Interface (CLI)
Menu-driven command-line interface for creating, updating, and browsing entries.


## Database Initialization
The project includes a seeded database with two static users to demonstrate authentication and user-based functionality.

<img width="904" height="134" alt="image" src="https://github.com/user-attachments/assets/3d9e1ea8-cc3d-4bde-9c02-335251b9ecbf" />

## UML class diagram
For handling emotion more effectively, I introduced an EmotionType class, which categorizes and organizes different emotions. EmotionType class could be enum, but I decided to switch field value to string for future scalability, Additionally, users have the option to add a profile picture to their account. However, this functionality is managed without a separate class, simplifying its implementation
<img width="898" height="551" alt="image" src="https://github.com/user-attachments/assets/5ecd8474-1abe-4777-b236-bcbd5aed2588" />

## Limitation
- **API**: Planned REST API endpoints for external integration.

- **Class**: `EmotionType` Currently implemented as string instead of enum for flexibility.

- **UI** :CLI prototype is functional but limited; future work could add a web or desktop GUI.

- **Database**: Migration issues occasionally required resets; indexing and timestamps could be improved.

- **Admin Role**: Future feature: admin flag for broader entry management.

- **Security**: Password hashing not yet implemented; would be added in production.

