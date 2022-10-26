-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE IF NOT EXISTS chores(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  isComplete BOOLEAN NOT NULL DEFAULT false
) default charset utf8 COMMENT '';

INSERT INTO chores(name, isComplete)
VALUES ('Do Dishes', false);

SELECT * FROM chores;

DELETE FROM chores WHERE id = 8; 