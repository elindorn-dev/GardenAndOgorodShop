-- Создание БД
CREATE DATABASE IF NOT EXISTS `garden_and_ogorod_shop` CHARACTER SET utf8;
USE `garden_and_ogorod_shop`;

-- Создание таблицы roles
CREATE TABLE IF NOT EXISTS roles (
    role_id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(50) UNIQUE NOT NULL,
    descript VARCHAR(255)
);

-- Создание таблицы users
CREATE TABLE IF NOT EXISTS users (
    users_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role_id INT,
    last_login_date DATETIME,
    notes TEXT,

    FOREIGN KEY (role_id) REFERENCES roles(role_id)
);

-- Создание таблицы employees
CREATE TABLE IF NOT EXISTS employees (
    employees_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    fathers_name VARCHAR(255),
    birth_day DATE,
    gender ENUM('мужской', 'женский'),
    phone_number VARCHAR(20),
    email VARCHAR(255) UNIQUE,
    address VARCHAR(255),
    position VARCHAR(255),
    hire_date DATE NOT NULL,
    salary INT NOT NULL,
    termination_date DATE,
    users_id INT,
    notes TEXT,
    photo BLOB,
    
    FOREIGN KEY (users_id) REFERENCES users(users_id)
);

-- ____________СДЕЛАЛ ЛЮДЕЙ____________

-- Создание таблицы orders
CREATE TABLE IF NOT EXISTS orders (
    orders_id INT PRIMARY KEY AUTO_INCREMENT,
    employees_id INT,
    order_date DATETIME NOT NULL,
    order_status ENUM('Обработка', 'Отменено', 'Успешно') DEFAULT 'Обработка', 
    payment_method ENUM('Безналичными', 'Наличными'),
    total_cost DECIMAL(10, 2) NOT NULL,
    tax_amount DECIMAL(10, 2) DEFAULT 0,
    notes TEXT,

    FOREIGN KEY (employees_id) REFERENCES employees(employees_id)
);

-- Создание картеГеоргий
CREATE TABLE IF NOT EXISTS categories (
    categories_id INT PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(255) NOT NULL,
    descript TEXT
);

-- Создание таблицы brands
CREATE TABLE IF NOT EXISTS brands (
    brands_id INT PRIMARY KEY AUTO_INCREMENT,
    brand_name VARCHAR(255) NOT NULL,
    descript TEXT,
    email VARCHAR(255),
    phone_number VARCHAR(20),
    legal_address VARCHAR(255)
);

-- Создание таблицы suppliers
CREATE TABLE IF NOT EXISTS suppliers (
    suppliers_id INT PRIMARY KEY AUTO_INCREMENT,
    supplier_name VARCHAR(255) NOT NULL,
    descript TEXT,
    email VARCHAR(255),
    phone_number VARCHAR(20),
    legal_address VARCHAR(255),
    registration_number_inn VARCHAR(50) UNIQUE
);

-- Создание таблицы Продуктов
CREATE TABLE products (
    products_id INT PRIMARY KEY AUTO_INCREMENT,
    products_name VARCHAR(255) NOT NULL,
    descript TEXT,
    price DECIMAL(10, 2) NOT NULL,
    categories_id INT NOT NULL,
    brands_id INT NOT NULL,
    is_available BOOLEAN NOT NULL DEFAULT TRUE,
    image BLOB,
    suppliers_id INT NOT NULL,
    seasonal_discount DECIMAL(5, 2) DEFAULT 0.00,

    FOREIGN KEY (categories_id) REFERENCES categories(categories_id),
    FOREIGN KEY (brands_id) REFERENCES brands(brands_id),
    FOREIGN KEY (suppliers_id) REFERENCES suppliers(suppliers_id)
);

-- Создание таблицы product_in_stock
CREATE TABLE IF NOT EXISTS product_in_stock (
    product_in_stock_id INT PRIMARY KEY AUTO_INCREMENT,
    products_id INT,
    amount_product INT NOT NULL,
    
    FOREIGN KEY (products_id) REFERENCES products(products_id)
);

-- Создание таблицы order_items
CREATE TABLE IF NOT EXISTS order_items (
    order_items_id INT PRIMARY KEY AUTO_INCREMENT,
    orders_id INT NOT NULL,
    products_id INT NOT NULL,
    
    FOREIGN KEY (products_id) REFERENCES products(products_id),
    FOREIGN KEY (orders_id) REFERENCES orders(orders_id)
);