/*
drop table customers;
drop table orders;
drop table location;
drop table inventory;
drop table product;
drop table cart;
drop table cartproduct;
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
	product_price decimal(19,4)

);

CREATE TABLE inventory (
    inventory_id int IDENTITY(20000, 1) PRIMARY KEY,	
	inventory_name varchar(100) NOT NULL,
	product_quantity varchar(500),
	location_id int NOT NULL,
	product_id int NOT NULL,

	FOREIGN KEY (location_id) REFERENCES location(location_id),
	FOREIGN KEY (product_id) REFERENCES product(product_id)

);



CREATE TABLE cart (
	cart_id int IDENTITY(80000, 1) PRIMARY KEY,
	customer_id int NOT NULL,
	product_cart_quantity int,

	FOREIGN KEY (customer_id) REFERENCES customer(customer_id)

);

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



	FOREIGN KEY (cart_id) REFERENCES cart(cart_id),
	FOREIGN KEY (product_id) REFERENCES product(product_id)
);



--seed data