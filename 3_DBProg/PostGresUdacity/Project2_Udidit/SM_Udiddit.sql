================================================================= =================================================================
================================================================= =================================================================
======================  EXISITING DATA ANAYLYSIS ==================
		
			Table "public.bad_posts"
				Column    |          Type           |                       Modifiers                        
			--------------+-------------------------+--------------------------------------------------------
			 id           | integer                 | not null default nextval('bad_posts_id_seq'::regclass)
			 topic        | character varying(50)   | 
			 username     | character varying(50)   | 
			 title        | character varying(150)  | 
			 url          | character varying(4000) | default NULL::character varying
			 text_content | text                    | 
			 upvotes      | text                    | 
			 downvotes    | text                    | 
			Indexes:
				"bad_posts_pkey" PRIMARY KEY, btree (id)


			Table "public.bad_comments"
				Column    |         Type          |                         Modifiers                         
			--------------+-----------------------+-----------------------------------------------------------
			 id           | integer               | not null default nextval('bad_comments_id_seq'::regclass)
			 username     | character varying(50) | 
			 post_id      | bigint                | 
			 text_content | text                  | 
			Indexes:
				"bad_comments_pkey" PRIMARY KEY, btree (id)	





================================================================= =================================================================
================================================================= =================================================================
======================  PART 2: CREATE TABLES ======================  


--TABLE#1
CREATE TABLE "users"(
id SERIAL,
name VARCHAR(50),
PRIMARY KEY (id),
 CONSTRAINT usernamelen CHECK(length("name") > 0 AND length("name") <=25),
 CONSTRAINT uniqname UNIQUE("name")
);
CREATE INDEX "userindx" ON "users" ("id");


--TABLE#2
CREATE TABLE "topics"(
topicID SERIAL,
name VARCHAR(30),
description VARCHAR(500),    
PRIMARY KEY(topicID),    
CONSTRAINT uniqtopic UNIQUE("name"),
CONSTRAINT topiclen CHECK(length("name") > 0)   
);
CREATE INDEX "topicsname" ON "topics" ("name");


--TABLE#3
CREATE TABLE "posts"(
id INTEGER,
title VARCHAR(150),
topicid INTEGER,
userid INTEGER,
text_content TEXT,
url VARCHAR(4000),
posttime  DATE,     
CONSTRAINT topicnotnull CHECK(topicid  <> NULL),    
CONSTRAINT postsprime PRIMARY KEY(id),    
CONSTRAINT fk_topic FOREIGN KEY(topicid) REFERENCES "topics" ON DELETE CASCADE,
CONSTRAINT fk_user  FOREIGN KEY(userid) REFERENCES "users" ON DELETE SET NULL,
CONSTRAINT nonemptytopic CHECK(length(title) > 0),
CONSTRAINT urlortxt  CHECK( (length(url) > 0  AND  length(text_content) = 0) OR (length(url) = 0  AND  length(text_content) > 0) )   
);
CREATE INDEX "postindx" ON "posts" ("title");


--TABLE#4
CREATE TABLE "comments"(
id SERIAL,
textContent TEXT,
userid INTEGER,
topicid INTEGER,    
postid INTEGER,
parentid INTEGER,
commenttime  DATE,    
CONSTRAINT  commentsnonempty CHECK(LENGTH(TRIM(textContent)) > 0),    
CONSTRAINT commentsprime PRIMARY KEY(ID),
CONSTRAINT fktable_user FOREIGN KEY(userid) REFERENCES "users" ON DELETE SET NULL,
CONSTRAINT fktable_topic FOREIGN KEY(topicid) REFERENCES "topics"    
);
CREATE INDEX "commentindx" ON "comments" ("id");



--TABLE#5
CREATE TABLE "votes"(
userid integer,
postid  integer,
vote smallint,
votetime DATE,   
CONSTRAINT postnotnull CHECK(postid <> NULL, 
CONSTRAINT votesprimary PRIMARY KEY (userid, postid),
CONSTRAINT fkvotesuser FOREIGN KEY(userid) REFERENCES "users" ON DELETE SET NULL,
CONSTRAINT fkvotespost FOREIGN KEY(postid) REFERENCES "posts" ON DELETE CASCADE,
CONSTRAINT limitvoteval CHECK( vote = 1 OR vote = -1)     
);
CREATE INDEX "votesindx" ON "votes" ("userid");


==========================================================================================================





================================================================= =================================================================
================================================================= =================================================================
====================== PART 3  DATA MIGRATION =============================

                TRUNCATE TABLE users, posts, comments, votes, topics;
                TRUNCATE TABLE users, posts, comments, votes, topics;
                TRUNCATE TABLE posts, comments, votes;
                DROP TABLE "posts" CASCADE;
                ALTER TABLE "comments" DROP CONSTRAINT fktable_post;



--TABLE "users" 1
INSERT INTO "users"("name") SELECT DISTINCT(bad_comments.username) FROM "bad_comments";
INSERT INTO "users"("name") SELECT DISTINCT(bad_posts.username)  FROM "bad_posts"  WHERE username NOT IN (SELECT "username" FROM bad_comments);

CREATE VIEW upusers AS SELECT REGEXP_SPLIT_TO_TABLE(upvotes, ',') AS username FROM bad_posts;
CREATE VIEW downusers AS SELECT REGEXP_SPLIT_TO_TABLE(downvotes, ',') AS username FROM bad_posts;

  --testing only
  --SELECT DISTINCT("username") FROM downusers  WHERE "username" NOT IN (SELECT upusers.username  FROM upusers) limit 3;

INSERT INTO "users"("name") SELECT  DISTINCT("username") FROM upusers  WHERE "username" NOT IN (SELECT "name" FROM users);
INSERT INTO "users"("name") SELECT DISTINCT("username") FROM downusers  WHERE "username" NOT IN (SELECT "name" FROM users);

 DROP VIEW  upusers;
 DROP VIEW downusers;
     
	 
	 
--TABLE "topics" 2
INSERT INTO "topics" ("name") SELECT DISTINCT("topic") FROM "bad_posts";





--TABLE "posts" 3
INSERT INTO "posts" ("id","title", "text_content", "url", "userid", topicid) 
SELECT bad_posts.id,"title", "text_content", "url", users.id, topics.topicid  FROM "bad_posts" 
JOIN users ON users.name = bad_posts.username 
JOIN topics ON topics.name = bad_posts.topic;



--TABLE "comments" 4
 INSERT INTO "comments" ("id", "textcontent", "postid", "parentid", "userid","topicid")
 SELECT  bad_comments.id, bad_comments.text_content, bad_comments.post_id, -1, users.id, posts.topicid
 FROM  bad_comments JOIN "users" ON bad_comments.username = users.name
                    JOIN "posts" ON  bad_comments.post_id = posts.id;



--TABLE "votes" 5
CREATE VIEW DOWNVOTERS AS SELECT bad_posts.id as postid, users.id as authorID, REGEXP_SPLIT_TO_TABLE(downvotes, ',') 
as DOWNVoter FROM bad_posts JOIN users ON users.name = bad_posts.username   ;

CREATE VIEW UPVOTERS  AS SELECT bad_posts.id as postid, users.id as authorID, REGEXP_SPLIT_TO_TABLE(upvotes, ',') 
as UPVoter FROM bad_posts JOIN users ON users.name = bad_posts.username   ;   
				
INSERT INTO "votes" ("postid", "userid", "vote") SELECT downvoters.postid, users.id , -1  FROM  downvoters  join users on downvoters.downvoter = users.name;
INSERT INTO "votes" ("postid", "userid", "vote") SELECT upvoters.postid, users.id , 1  FROM  upvoters  join users on upvoters.upvoter = users.name;
				
DROP VIEW DOWNVOTERS;
DROP VIEW UPVOTERS;


