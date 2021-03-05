drop table batch;
drop table trainers;
drop table associates;

create table associates
(
	id int identity primary key,
	/*you can start an identity at any key*/
	associateName nvarchar(100) not null,
	/*what's the difference between nvarchar and varchar? QC QUESTION ALERT	*/
	/* https://stackoverflow.com/questions/144283/what-is-the-difference-between-varchar-and-nvarchar */
	associateLocale varchar(2) not null,
	revaPoints int not null



);

create table trainers
(
	id int identity primary key,
	trainerName nvarchar(100) not null,
	campus varchar(3) not null,
	caffeineLevel int not null

);

create table batch
(
	id int identity primary key,
	associateID int references associates(id),
	trainerID int references trainers(id)
);

INSERT into associates (associateName, associateLocale, revaPoints) values
('Joaquin', 'PA', -10), ('Madeline', 'WA', 10), ('Jacob', 'FL', 0), ('Michael', 'AZ', 20), ('Janel', 'AZ', 50),
 ('Angeleen', 'TX', 30), ('Warren', 'NH', 40);
insert into trainers(trainerName, campus, caffeineLevel) values
('Marielle', 'USF', 5), ('Pushpinder', 'UTA', 50), ('Nick', 'UTA', 75), ('Mark', 'WVU', 16), ('Fred', 'UTA', 25);
insert into batch (associateID, trainerID) values
(3, 3), (1, 1), (2, 1), (4, 1), (6, 1), (7, 1);

select * from associates;

select * from trainers;
--I wanna know all trainers that currently have a batch
select trainerName from trainers inner join batch on trainers.id = batch.trainerID;
--If I just want all trainer names without duplications
select distinct trainerName from trainers inner join batch on trainers.id = batch.trainerID;
-- all things in left join that have fields for right join stuff
select * from trainers left join batch on trainers.id = batch.trainerID;
-- only things that batch has records on
select * from trainers right join batch on trainers.id = batch.trainerID;

--
select * from trainers full outer join batch on trainers.id = batch.trainerID right join associates on batch.associateID = associates.id;

-- to get all trainers from a batch using set operations
(select id from trainers) intersect (select trainerID from batch);
-- when doing set operations from two datasets, data types must match from both specific columns being queried

-- all trainers not in a batch
(select trainerName from trainers) except (select trainerName from trainers inner join batch on trainers.id = batch.trainerID);

-- trainers where the id is not in batch conjoined table
select trainerName from trainers where id not in (select trainerID from batch);