# DigitalEmotionDiary
 **Digital Emotion Diary** is a diary application designed to allow users to publish, manage, and engage with diary entries. Users can view public entries from other app users while maintaining control over their private entries. 

The application was designed with the following key features in mind:
 ### 1. Emotion and Background Color
 Given the emphasis on emotions in the app's name, each diary entry is associated with a background color that represents a specific emotion. 
 For example:
 Happy mood– `Yellow`
 Energized– `Orange`
 Stressed– `Red`
 Annoyed– `Black`
 
 If the application were to gain widespread use, I could conduct user surveys to refine these color-emotion combinations and potentially expand the options.
 
 ### 2. Image Upload
 To make entries more expressive, users have the option to upload at least one image per diary entry. Images can convey emotions or moments better than text in some cases. This feature is optional, allowing flexibility in user preferences.
 
 ### 3. Likes and Comments
 To increase user engagement, the app includes features for liking and commenting on diary
 entries:--
 Likes: A diary entry can receive likes from multiple users.
 Comments: Users can leave comments on entries to interact with one another.
 
 ### 4. Tags
 Tags enhance the organizational aspect of the app. I implemented a many-to-many relationship between tags and diary entries:--
 A single diary entry can have multiple tags.
 A single tag can be associated with multiple entries.
 
 ### 5. Filtering Options
 Users can filter their entries by mood or tags, enabling them to revisit specific emotional states or topics easily.

### 6. Command-Line Interface (CLI)
 The app features a menu-driven interface in the command line, allowing users to navigate
 and execute operations such as creating, updating, and filtering entries.


## Database Initialization
For this project, I initialized the database with two static users, laying the foundation for user-related functionalities.

<img width="904" height="134" alt="image" src="https://github.com/user-attachments/assets/3d9e1ea8-cc3d-4bde-9c02-335251b9ecbf" />

## UML class diagram
 For handling emotion more effectively, I introduced an EmotionType class, which categorizes and organizes different emotions. EmotionType class could be enum, but I decided to switch field value to string for future scalability, Additionally, users have the option to add a profile picture to their account. However, this functionality is managed without a separate class, simplifying its implementation
<img width="898" height="551" alt="image" src="https://github.com/user-attachments/assets/5ecd8474-1abe-4777-b236-bcbd5aed2588" />

## Limitation
- **API**: 
For further improvements, I'm planning to make controllers and API with endpoints.

- **Class**: EmotionType
It could be enum, but I changed it to type string for scalability in the future. Features : Like, Comment, Tag, Image

- **UI** :I aimed to implement CLI, but couldn’t manage it due to the time limit. Also it was quite limited to show it in console based frontend. UI/Login service has both UI logic and user authentication, I could improve that.

- **Database**: I experienced multiple errors while database migration, therefore I often choose to delete the migrated db, and migrate again. Everytime I did it, the field `Date.now` in DiaryEntry was updated. It became difficult to track when the original entry was
 created.

- **CLI**: I could make a new flag for the Admin role that is access for both private and public entries. In my setting with users, it’s not available for private entries. When I try to delete diaryEntry, I need to know about entryId. But it’s unable to search for an entryId for a specific entry by using GET_ALL currently.

- **Security**: I could add password hash for adding security, but I decided not to take this option this time.

