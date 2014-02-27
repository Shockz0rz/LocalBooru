LocalBooru. Find Your Stuff.
============================

What is LocalBooru?
-------------------

LocalBooru is a tag-based search system inspired by del.icio.us and the *booru imageboards. Written in C# and utilizing an internal SQLite database using the Toxi schema, it allows users to quickly and easily apply tags to virtually any kind of content accessible via their computers, and then find and open that content just as quickly when they need it again.

Content?
--------

Yes, content. Any content. The initial version of LocalBooru is designed to retrieve files on the user's local drive; however, the end goal is for the system to act as a Web bookmark storage system, as well as even searching for content on the user's local network. Moreover, LocalBooru will identify the *type* of content a search result contains, returning an appropriate "preview" snapshot for each result if possible, and--when the user selects a result--opening the content either internally or using the user's preferred program.

The ideal end result is that LocalBooru will act as a near-complete Windows Explorer(/equivalent) replacement, providing a universal front-end for users to Find Their Stuff. One planned element will be an auto-tag engine, detecting new files in watched folders and automatically applying tags based on content type and file name.

Okay, so how's it work?
-----------------------

Well, as mentioned above, it's written in C# on the .NET framework, and utilizes a SQLite database to track tags and content. It uses the Windows Presentation Foundation for the UI, though I eventually plan to make it cross-platform using Mono. As for the actually-complicated stuff, like displaying content previews? ...I have no idea yet. 'Tis a learning experience for me!
