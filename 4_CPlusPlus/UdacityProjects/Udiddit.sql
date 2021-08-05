TABLE#1
CREATE TABLE "users"(
id SERIAL,
name VARCHAR(50),
PRIMARY KEY (id),
 CONSTRAINT usernamelen CHECK(length("name") > 0 AND length("name") <=25),
 CONSTRAINT uniqname UNIQUE("name")
);
CREATE INDEX "userindx" ON "users" ("id");


TABLE#2
CREATE TABLE "topics"(
topicID SERIAL,
name VARCHAR(30),
description VARCHAR(500),    
PRIMARY KEY(topicID),    
CONSTRAINT uniqtopic UNIQUE("name"),
CONSTRAINT topiclen CHECK(length("name") > 0)   
);
CREATE INDEX "topicsname" ON "topics" ("name");


TABLE#3
CREATE TABLE "posts"(
id INTEGER,
title VARCHAR(150),
topicid INTEGER,
userid INTEGER,
text_content TEXT,
url VARCHAR(4000),    
CONSTRAINT postsprime PRIMARY KEY(id),    
CONSTRAINT fk_topic FOREIGN KEY(topicid) REFERENCES "topics" ON DELETE CASCADE,
CONSTRAINT fk_user  FOREIGN KEY(userid) REFERENCES "users" ON DELETE SET NULL,
CONSTRAINT nonemptytopic CHECK(length(title) > 0),
CONSTRAINT urlortxt  CHECK( (length(url) > 0  AND  length(text_content) = 0) OR (length(url) = 0  AND  length(text_content) > 0) )   
);
CREATE INDEX "postindx" ON "posts" ("title");


TABLE#4
CREATE TABLE "comments"(
id SERIAL,
textContent TEXT,
userid INTEGER,
topicid INTEGER,    
postid INTEGER,
parentid INTEGER,    
CONSTRAINT  commentsnonempty CHECK(LENGTH(TRIM(textContent)) > 0),    
CONSTRAINT commentsprime PRIMARY KEY(ID),
CONSTRAINT fktable_user FOREIGN KEY(userid) REFERENCES "users" ON DELETE SET NULL,
CONSTRAINT fktable_topic FOREIGN KEY(topicid) REFERENCES "topics"    
);
CREATE INDEX "commentindx" ON "comments" ("id");



TABLE#5
CREATE TABLE "votes"(
userid integer,
postid  integer,
vote smallint,    
CONSTRAINT votesprimary PRIMARY KEY (userid, postid),
CONSTRAINT fkvotesuser FOREIGN KEY(userid) REFERENCES "users" ON DELETE SET NULL,
CONSTRAINT fkvotespost FOREIGN KEY(postid) REFERENCES "posts" ON DELETE CASCADE,
CONSTRAINT limitvoteval CHECK( vote = 1 OR vote = -1)     
);
CREATE INDEX "votesindx" ON "votes" ("userid");
