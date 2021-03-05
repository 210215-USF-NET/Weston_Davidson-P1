/*
drop table customers;
drop table orders;
drop table location;
drop table inventory;
drop table product;
drop table cart;
drop table cartproduct;

drop table cartproduct;
drop table cart;
drop table product;
drop table inventory;
drop table location;
drop table orders;
drop table customer;
*/

CREATE TABLE customer (
    customer_id int IDENTITY(30000, 1) PRIMARY KEY,
    customer_fname varchar(50) NOT NULL,
	customer_lname varchar(50) NOT NULL,
	customer_passwordhash varchar(50) NOT NULL,
    customer_username varchar(50) NOT NULL

);


CREATE TABLE location (
    location_id int IDENTITY(20000, 1) PRIMARY KEY,
	location_name varchar(50) NOT NULL,
	location_address varchar(100) NOT NULL

);

CREATE TABLE product (
    product_id int IDENTITY(10000, 1) PRIMARY KEY,	
	product_name varchar(50) NOT NULL,
	product_description varchar(500),
	product_price decimal(19,4),
	manufacturer varchar(50)

);

-- adding manufacturer to product
/*
ALTER TABLE product
ADD manufacturer varchar(50);
*/

select * from inventory;

CREATE TABLE inventory (
    inventory_id int IDENTITY(20000, 1) PRIMARY KEY,	
	inventory_name varchar(100) NOT NULL,
	product_quantity int,
	location_id int NOT NULL,
	product_id int NOT NULL,

	FOREIGN KEY (location_id) REFERENCES location(location_id),
	FOREIGN KEY (product_id) REFERENCES product(product_id)

);

/*
--change product_quantity to int instead of string
ALTER TABLE inventory
ALTER COLUMN product_quantity int;
*/
--select * from location;

CREATE TABLE cart (
	cart_id int IDENTITY(80000, 1) PRIMARY KEY,
	customer_id int NOT NULL,

	FOREIGN KEY (customer_id) REFERENCES customer(customer_id)

);

-- moving table cart quantity to cartproducts as product_count
/*ALTER TABLE cart
DROP COLUMN product_cart_quantity;
*/

CREATE TABLE orders (
	order_id int IDENTITY(60000, 1) PRIMARY KEY,
	order_date datetime NOT NULL,

	--FKs
	location_id int NOT NULL,
	customer_id int NOT NULL,
	cart_id int NOT NULL,

	FOREIGN KEY (location_id) REFERENCES location(location_id),
	FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
	FOREIGN KEY (cart_id) REFERENCES cart(cart_id)
);

CREATE TABLE cartproducts (

	cart_products_id int IDENTITY (90000, 1) PRIMARY KEY,
	product_count int,
	
	--FKs
	cart_id int NOT NULL,
	product_id int NOT NULL,
	inventory_id int,



	FOREIGN KEY (cart_id) REFERENCES cart(cart_id),
	FOREIGN KEY (product_id) REFERENCES product(product_id),
	FOREIGN KEY (inventory_id) REFERENCES inventory(inventory_id)
);

-- added in a FK for inventory_id
/*ALTER TABLE cartproducts
ADD inventory_id int
ADD FOREIGN KEY (inventory_id) REFERENCES inventory(inventory_id);
*/



---------------------------------------------------seed data---------------------------------------

-- customers
INSERT INTO customer (customer_fname, customer_lname, customer_passwordhash, customer_username)
VALUES ('Weston', 'Davidson', 'coolpassword30', 'westond'),
('John', 'Doe', 'joeybags0039', 'igloomachine1');

-- locations
INSERT INTO location (location_name, location_address)
VALUES ('Tampa', '289 Driftwood St.'), ('Orlando', '7327 Michael Rd.');

-- products
INSERT INTO product (manufacturer, product_name, product_description, product_price)
VALUES ('Korg', 'Minilogue', 'The Korg Minilogue is a two VCO per-voice, four-voice, polyphonic analog synthesizer from Korg, designed by Korg engineer and synthesizer designer Tatsuya Takahashi.',
'499.99'), ('Arturia', 'MicroBrute', 'Packed with mixable waveforms, a new sub-oscillator design, the famous Steiner-Parker multimode filter, a super-fast envelope, a syncable LFO, our new step sequencer and a patchable mod matrix, the MicroBrute is a landmark new synth at an incredible price.',
'349.00')

-- location inventory of products
INSERT INTO inventory (inventory_name, location_id, product_id, product_quantity)
VALUES ('Minilogues', '20000', '10000', '23'),
('Minilogues', '20001', '10000', '12');

-- cart ID/customer tracking
INSERT INTO cart (customer_id)
VALUES ('30000');

-- cartproducts
INSERT INTO cartproducts(cart_id, product_id, inventory_id, product_count)
VALUES ('80000', '10000', '20000', '3');


-- orders
INSERT INTO orders (order_date, location_id, customer_id, cart_id)
VALUES (GETDATE(), '20000', '30000', '80000');

select * from orders;

--playing with values
select * from inventory INNER JOIN location ON inventory.location_id = location.location_id;


-- need to create queries that would retrieve/update/delete data as needed i think?




-- VIEWS FOR INVENTORIES AT SPECIFIED LOCATIONS
GO
CREATE VIEW tampaView AS
SELECT *
FROM inventory
WHERE location_id = '20000';


GO
CREATE VIEW orlandoView AS
SELECT *
FROM inventory
WHERE location_id = '20001';


GO
select * from location;


-- query the views
GO
SELECT * from tampaView;

SELECT * from orlandoView;


select * from product;

select * from cart;

select * from orders;