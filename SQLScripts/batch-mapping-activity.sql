--1. Add 5 associates to the associate table
INSERT into associates (associateName, associateLocale, revaPoints) values
('Weston', 'FL', 30), ('Zhongkai', 'CA', 10), ('Douglas', 'AL', 40), ('Ulices', 'CA', 60), ('Zachary', 'IL', 70);

--2. get all associates that live in a certain state
SELECT * FROM associates where associateLocale = 'IL';

--3. get the number of associates living in the various states
	-- give numer in descending andn ascending order

SELECT associateLocale, COUNT(associateLocale) FROM associates group by associateLocale ORDER BY COUNT(associateLocale) ASC;

SELECT associateLocale, COUNT(associateLocale) FROM associates group by associateLocale ORDER BY COUNT(associateLocale) DESC;

--4. Use joins, set operations, and subqueries to:
	-- a. get all trainers without associates
	-- alt option(select trainerName from trainers) except (select trainerName from trainers inner join batch on trainers.id = batch.trainerID);
		
		select trainerName from trainers left outer join batch on trainers.id = trainerID where trainerID is null;

	-- b. get all the associates mapped to a trainer
	-- alt option (Ulices):
	select trainerName, associateName from trainers inner join batch on trainers.id = batch.trainerID inner join associates on associates.id = associateID;
	
	select trainerName from trainers left outer join batch on associates.id = associateID where trainerID is not null;

	-- c. get all associates without a trainer
	-- alternative option (Ulices): 
	--select * from associates where associatename not in (select associateName from associates inner join batch on associates.id = batch.associateID);
	-- my solution:
	select associateName from associates left outer join batch on associates.id = associateID where associateID is null;




-- additional random queries
	select * from associates;
	select * from batch;
	select * from trainers;

(select * from Associates) 
except 
(select associateName from associates full outer join batch on associateid = batch.associateID);