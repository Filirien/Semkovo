# Semkovo
Web project for course Teamwork Course

The application provides information about Semkovo resort - Belitsa.

The web application is supposed to include three parts:
1. Blog-like pages with articles about travel destinations
2. List of interesting events around Semkovo a user can visit
3. Administration interface for publishing articles and events

The application provides following functionality to all visitors (without authentication):
1. Read articles about travel destinations
2. View pictures
3. View comments
4. View information about events

Registered users can:
1. Upload picture
2. Write articles and comments
3. Like pictures, articles and comments
4. Update or delete their articles, comments and pictures
5. Manage their profile

Authenticated administrators can:
1. Create / edit / delete events
2. Moderate messages left by registered users
3. Ban users who post inappropriate messages


The information about users, articles, events is stored in a database SemkovoDb.

The database include following tables:
1. Users - Id, Fullname, Password, Email
2. Articles - Id, Title, Content, AuthorId, CreatedOn
3. Comments - Id, Content, ArticleId, AuthorId, CreatedOn
4. Pictures - Id, ImageUrl, CreatedOn
5. ArticleVote - ArticleId, UserId, Count
6. Events - Id, Name, StartDate, EndDate, Creator, Limit(max count participants)
7. UserEvents - ParticipantId, EventId

