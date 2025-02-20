-- Создание БД
CREATE DATABASE IF NOT EXISTS `garden_and_ogorod_shop` CHARACTER SET utf8;
USE `garden_and_ogorod_shop`;

-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: garden_and_ogorod_shop
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `brands`
--

DROP TABLE IF EXISTS `brands`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brands` (
  `brands_id` int NOT NULL AUTO_INCREMENT,
  `brand_name` varchar(255) NOT NULL,
  `descript` text,
  `email` varchar(255) DEFAULT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `legal_address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`brands_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brands`
--

LOCK TABLES `brands` WRITE;
/*!40000 ALTER TABLE `brands` DISABLE KEYS */;
INSERT INTO `brands` VALUES (1,'Садовый Мастер','Производитель высококачественных садовых инструментов','info@sadovyi-master.ru','+7 (495) 123-45-67','ул. Ленина, 1, Москва, Россия'),(2,'Зеленый Мир','Инновационные решения для ухода за растениями','sales@zelenyi-mir.ru','+7 (812) 987-65-43','Невский проспект, 2, Санкт-Петербург, Россия'),(3,'Природа+','Органические удобрения и добавки к почве','contact@priroda-plus.ru','+7 (383) 234-56-78','ул. Кирова, 3, Новосибирск, Россия'),(4,'Чистый Сад','Эффективные средства для борьбы с сорняками','support@chistyi-sad.ru','+7 (843) 345-67-89','ул. Баумана, 4, Казань, Россия'),(5,'АкваТех','Экономичные системы полива для устойчивого садоводства','inquiries@akvateh.ru','+7 (863) 456-78-90','ул. Большая Садовая, 5, Ростов-на-Дону, Россия'),(6,'Растишка','Поставщик контейнеров и расходных материалов для выращивания','sales@rastishka.ru','+7 (343) 567-89-01','ул. 8 Марта, 6, Екатеринбург, Россия'),(7,'Солнечный Свет','Решения для наружного освещения сада','hello@solnechnyi-svet.ru','+7 (3842) 678-90-12','ул. Кузнецкий Мост, 7, Кемерово, Россия'),(8,'Защитник','Защитная одежда для садоводов','customerservice@zashitnik.ru','+7 (846) 789-01-23','ул. Самарская, 8, Самара, Россия'),(9,'Цветочный Рай','Специализированные удобрения для цветущих растений','contact@cvetochnyi-rai.ru','+7 (8512) 890-12-34','ул. Ленина, 9, Астрахань, Россия'),(10,'ПочваЭксперт','Наборы для анализа почвы и услуги по анализу','info@pochvaexpert.ru','+7 (800) 200-30-40','ул. Академика Лаврентьева, 10, Москва, Россия');
/*!40000 ALTER TABLE `brands` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `categories_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(255) NOT NULL,
  `descript` text,
  PRIMARY KEY (`categories_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Семена','Различные типы семян растений для вашего сада'),(2,'Инструменты','Садовые инструменты, ручные инструменты и электроинструменты'),(3,'Удобрения','Удобрения и подкормка для растений для улучшения роста'),(4,'Борьба с вредителями','Решения для борьбы с вредителями и болезнями'),(5,'Полив','Системы полива, шланги и разбрызгиватели'),(6,'Грунт и мульча','Почвы для горшков, компост и варианты мульчи'),(7,'Декор','Садовые украшения и уличная мебель'),(8,'Контейнеры','Горшки, кашпо и другие контейнеры для выращивания'),(9,'Освещение','Решения для наружного освещения вашего сада'),(10,'Защитная одежда','Перчатки, маски и другая защитная одежда');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `employees_id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `fathers_name` varchar(255) DEFAULT NULL,
  `birth_day` date DEFAULT NULL,
  `gender` enum('мужской','женский') DEFAULT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `position` varchar(255) DEFAULT NULL,
  `hire_date` date NOT NULL,
  `salary` int NOT NULL,
  `termination_date` date DEFAULT NULL,
  `users_id` int DEFAULT NULL,
  `notes` text,
  `photo` blob,
  PRIMARY KEY (`employees_id`),
  UNIQUE KEY `email` (`email`),
  KEY `users_id` (`users_id`),
  CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`users_id`) REFERENCES `users` (`users_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Иван','Иванов','Иванович','1985-05-10','мужской','+7 (916) 123-45-67','ivan.ivanov@example.com','Москва, ул. Ленина, д. 1','Менеджер','2020-01-15',60000,NULL,2,'Опыт работы 5 лет',NULL),(2,'Петр','Петров','Петрович','1990-08-22','мужской','+7 (926) 987-65-43','petr.petrov@example.com','Санкт-Петербург, Невский пр., д. 2','Продавец-консультант','2021-03-01',45000,NULL,3,'Отличные навыки общения',NULL),(3,'Анна','Сидорова','Михайловна','1988-12-05','женский','+7 (903) 345-67-89','anna.sidorova@example.com','Казань, ул. Баумана, д. 3','Бухгалтер','2022-05-20',55000,NULL,4,'Внимательность и аккуратность',NULL),(4,'Елена','Смирнова','Алексеевна','1992-03-15','женский','+7 (915) 456-78-90','elena.smirnova@example.com','Екатеринбург, ул. Малышева, д. 4','Кассир','2023-01-10',40000,NULL,5,'Быстро обучаемая',NULL),(5,'Дмитрий','Кузнецов','Сергеевич','1987-07-01','мужской','+7 (925) 567-89-01','dmitry.kuznetsov@example.com','Новосибирск, Красный пр., д. 5','Кладовщик','2020-11-01',48000,NULL,6,'Ответственность и пунктуальность',NULL),(6,'Ольга','Васильева','Ивановна','1995-01-28','женский','+7 (905) 678-90-12','olga.vasilieva@example.com','Ростов-на-Дону, ул. Садовая, д. 6','Уборщица','2021-07-01',35000,NULL,7,'Трудолюбивая и чистоплотная',NULL),(7,'Сергей','Федоров','Дмитриевич','1983-11-18','мужской','+7 (918) 789-01-23','sergey.fedorov@example.com','Самара, ул. Куйбышева, д. 7','Охранник','2022-09-15',42000,NULL,8,'Опыт работы в охране',NULL),(8,'Татьяна','Николаева','Петровна','1991-06-03','женский','+7 (960) 890-12-34','tatiana.nikolaeva@example.com','Уфа, ул. Проспект Октября, д. 8','Администратор','2023-03-20',50000,NULL,9,'Организованность и коммуникабельность',NULL),(9,'Андрей','Степанов','Андреевич','1986-09-25','мужской','+7 (985) 901-23-45','andrey.stepanov@example.com','Воронеж, ул. Революции, д. 9','Водитель','2020-05-01',43000,NULL,10,'Безаварийное вождение',NULL),(10,'Наталья','Волкова','Сергеевна','1993-04-12','женский','+7 (906) 012-34-56','natalia.volkova@example.com','Красноярск, ул. Мира, д. 10','Аналитик','2021-09-01',58000,NULL,NULL,'Специалист по анализу данных',NULL);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_items`
--

DROP TABLE IF EXISTS `order_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_items` (
  `order_items_id` int NOT NULL AUTO_INCREMENT,
  `orders_id` int NOT NULL,
  `products_id` int NOT NULL,
  PRIMARY KEY (`order_items_id`),
  KEY `products_id` (`products_id`),
  KEY `orders_id` (`orders_id`),
  CONSTRAINT `order_items_ibfk_1` FOREIGN KEY (`products_id`) REFERENCES `products` (`products_id`),
  CONSTRAINT `order_items_ibfk_2` FOREIGN KEY (`orders_id`) REFERENCES `orders` (`orders_id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_items`
--

LOCK TABLES `order_items` WRITE;
/*!40000 ALTER TABLE `order_items` DISABLE KEYS */;
INSERT INTO `order_items` VALUES (1,1,1),(2,1,3),(3,1,5),(4,2,2),(5,2,4),(6,3,6),(7,3,8),(8,3,10),(9,4,7),(10,4,9),(11,5,11),(12,5,13),(13,6,12),(14,6,14),(15,7,15),(16,7,17),(17,8,16),(18,8,18),(19,9,19),(20,9,21),(21,10,20),(22,10,22),(23,11,23),(24,11,25),(25,12,24),(26,12,26),(27,13,27),(28,13,29),(29,14,28),(30,14,30),(31,15,31),(32,15,33),(33,16,32),(34,16,34),(35,17,35),(36,17,37),(37,18,36),(38,18,38),(39,19,39),(40,19,41),(41,20,40),(42,20,42),(43,21,43),(44,21,45),(45,22,44),(46,22,46),(47,23,47),(48,23,49),(49,24,48),(50,24,50);
/*!40000 ALTER TABLE `order_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `orders_id` int NOT NULL AUTO_INCREMENT,
  `employees_id` int DEFAULT NULL,
  `order_date` datetime NOT NULL,
  `order_status` enum('Обработка','Отменено','Успешно') DEFAULT 'Обработка',
  `payment_method` enum('Безналичными','Наличными') DEFAULT NULL,
  `total_cost` decimal(10,2) NOT NULL,
  `tax_amount` decimal(10,2) DEFAULT '0.00',
  `notes` text,
  PRIMARY KEY (`orders_id`),
  KEY `employees_id` (`employees_id`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`employees_id`) REFERENCES `employees` (`employees_id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,'2024-01-20 10:15:00','Успешно','Безналичными',125.50,10.00,'Оплата прошла успешно'),(2,2,'2024-01-20 11:30:00','Обработка','Наличными',75.00,0.00,'Заказ на рассмотрении'),(3,1,'2024-01-21 14:00:00','Успешно','Безналичными',210.75,15.00,'Заказ доставлен'),(4,3,'2024-01-21 16:45:00','Отменено','Наличными',50.00,0.00,'Заказ отменен клиентом'),(5,2,'2024-01-22 09:00:00','Обработка','Безналичными',99.99,8.00,'Заказ обрабатывается'),(6,4,'2024-01-22 10:45:00','Успешно','Наличными',180.00,12.00,'Заказ получен'),(7,1,'2024-01-23 13:15:00','Обработка','Безналичными',45.20,3.00,'Ожидание оплаты'),(8,3,'2024-01-23 15:30:00','Успешно','Наличными',300.00,20.00,'Заказ выдан'),(9,2,'2024-01-24 11:00:00','Отменено','Безналичными',60.00,0.00,'Некорректные данные'),(10,4,'2024-01-24 13:45:00','Обработка','Наличными',110.50,9.00,'Проверка наличия товаров'),(11,1,'2024-01-25 08:30:00','Успешно','Безналичными',25.00,2.00,'Заказ отправлен'),(12,3,'2024-01-25 16:00:00','Обработка','Безналичными',80.00,6.00,'Сборка заказа'),(13,2,'2024-01-26 10:00:00','Успешно','Наличными',150.00,10.00,'Заказ доставлен курьером'),(14,4,'2024-01-26 12:15:00','Отменено','Наличными',40.00,0.00,'Недостаточно товаров на складе'),(15,1,'2024-01-27 15:00:00','Обработка','Безналичными',70.75,5.00,'Ожидание подтверждения'),(16,3,'2024-01-27 17:30:00','Успешно','Безналичными',220.00,18.00,'Заказ передан в доставку'),(17,2,'2024-01-28 09:45:00','Отменено','Наличными',55.00,0.00,'Отменено по запросу клиента'),(18,4,'2024-01-28 11:15:00','Обработка','Наличными',130.20,11.00,'Подготовка к отправке'),(19,1,'2024-01-29 14:30:00','Успешно','Безналичными',35.99,3.00,'Заказ получен'),(20,3,'2024-01-29 16:00:00','Обработка','Безналичными',90.00,7.00,'Сборка товаров'),(21,2,'2024-01-30 10:30:00','Успешно','Наличными',165.50,13.00,'Заказ в пути'),(22,4,'2024-01-30 12:00:00','Отменено','Наличными',65.00,0.00,'Неправильный адрес доставки'),(23,1,'2024-01-31 13:00:00','Обработка','Безналичными',85.00,6.00,'Ожидание оплаты'),(24,3,'2024-01-31 14:30:00','Успешно','Безналичными',280.00,22.00,'Заказ получен клиентом'),(25,2,'2024-02-01 08:00:00','Отменено','Наличными',42.00,0.00,'Товар отсутствует'),(26,4,'2024-02-01 10:00:00','Обработка','Наличными',105.00,8.00,'Проверка заказа'),(27,1,'2024-02-02 11:45:00','Успешно','Безналичными',190.00,16.00,'Заказ доставлен'),(28,3,'2024-02-02 15:00:00','Обработка','Безналичными',55.00,4.00,'Сборка заказа'),(29,2,'2024-02-03 09:30:00','Успешно','Наличными',320.00,25.00,'Заказ выдан'),(30,4,'2024-02-03 11:00:00','Отменено','Наличными',70.00,0.00,'Некорректные данные'),(31,1,'2024-02-04 14:15:00','Обработка','Безналичными',115.75,9.00,'Ожидание оплаты'),(32,3,'2024-02-04 16:30:00','Успешно','Безналичными',140.00,11.00,'Заказ готов к отправке'),(33,2,'2024-02-05 10:00:00','Отменено','Наличными',62.00,0.00,'Отменено клиентом'),(34,4,'2024-02-05 13:00:00','Обработка','Наличными',95.00,7.00,'Проверка на складе'),(35,1,'2024-02-06 08:45:00','Успешно','Безналичными',200.00,17.00,'Заказ доставлен курьером'),(36,3,'2024-02-06 11:30:00','Обработка','Безналичными',75.00,6.00,'Сборка заказа'),(37,2,'2024-02-07 14:00:00','Успешно','Наличными',275.00,20.00,'Заказ получен'),(38,4,'2024-02-07 16:15:00','Отменено','Наличными',48.00,0.00,'Нет товара'),(39,1,'2024-02-08 09:00:00','Обработка','Безналичными',120.00,9.00,'Ждем подтверждения'),(40,3,'2024-02-08 11:30:00','Успешно','Безналичными',300.00,23.00,'Заказ выдан'),(41,2,'2024-02-09 12:00:00','Отменено','Наличными',58.00,0.00,'Неверные данные'),(42,4,'2024-02-09 14:45:00','Обработка','Наличными',112.50,9.00,'Проверка наличия'),(43,1,'2024-02-10 10:15:00','Успешно','Безналичными',38.00,3.00,'Заказ отправлен'),(44,3,'2024-02-10 16:00:00','Обработка','Безналичными',82.00,6.00,'Сборка товаров'),(45,2,'2024-02-11 11:00:00','Успешно','Наличными',155.00,11.00,'Заказ передан'),(46,4,'2024-02-11 13:30:00','Отменено','Наличными',45.00,0.00,'Ошибка доставки'),(47,1,'2024-02-12 08:30:00','Обработка','Безналичными',78.50,6.00,'Ожидание оплаты'),(48,3,'2024-02-12 14:00:00','Успешно','Безналичными',215.00,18.00,'Заказ доставлен'),(49,2,'2024-02-13 10:00:00','Отменено','Наличными',53.00,0.00,'Нет в наличии'),(50,4,'2024-02-13 12:30:00','Обработка','Наличными',100.00,8.00,'Заказ обрабатывается');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_in_stock`
--

DROP TABLE IF EXISTS `product_in_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_in_stock` (
  `product_in_stock_id` int NOT NULL AUTO_INCREMENT,
  `products_id` int DEFAULT NULL,
  `amount_product` int NOT NULL,
  PRIMARY KEY (`product_in_stock_id`),
  KEY `products_id` (`products_id`),
  CONSTRAINT `product_in_stock_ibfk_1` FOREIGN KEY (`products_id`) REFERENCES `products` (`products_id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_in_stock`
--

LOCK TABLES `product_in_stock` WRITE;
/*!40000 ALTER TABLE `product_in_stock` DISABLE KEYS */;
INSERT INTO `product_in_stock` VALUES (1,1,150),(2,2,200),(3,3,75),(4,4,120),(5,5,90),(6,6,180),(7,7,60),(8,8,110),(9,9,80),(10,10,130),(11,11,100),(12,12,160),(13,13,50),(14,14,140),(15,15,70),(16,16,190),(17,17,40),(18,18,105),(19,19,95),(20,20,155),(21,21,115),(22,22,170),(23,23,55),(24,24,135),(25,25,65),(26,26,185),(27,27,45),(28,28,108),(29,29,92),(30,30,158),(31,31,112),(32,32,175),(33,33,58),(34,34,132),(35,35,68),(36,36,188),(37,37,48),(38,38,103),(39,39,97),(40,40,152),(41,41,118),(42,42,165),(43,43,52),(44,44,145),(45,45,72),(46,46,195),(47,47,35),(48,48,106),(49,49,85),(50,50,168);
/*!40000 ALTER TABLE `product_in_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `products_id` int NOT NULL AUTO_INCREMENT,
  `products_name` varchar(255) NOT NULL,
  `descript` text,
  `price` decimal(10,2) NOT NULL,
  `categories_id` int NOT NULL,
  `brands_id` int NOT NULL,
  `is_available` tinyint(1) NOT NULL DEFAULT '1',
  `image` blob,
  `suppliers_id` int NOT NULL,
  `seasonal_discount` decimal(5,2) DEFAULT '0.00',
  PRIMARY KEY (`products_id`),
  KEY `categories_id` (`categories_id`),
  KEY `brands_id` (`brands_id`),
  KEY `suppliers_id` (`suppliers_id`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`categories_id`) REFERENCES `categories` (`categories_id`),
  CONSTRAINT `products_ibfk_2` FOREIGN KEY (`brands_id`) REFERENCES `brands` (`brands_id`),
  CONSTRAINT `products_ibfk_3` FOREIGN KEY (`suppliers_id`) REFERENCES `suppliers` (`suppliers_id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Семена Томатов \'Бычье сердце\'','Крупноплодный сорт томатов для открытого грунта',1.50,1,1,1,NULL,1,0.00),(2,'Газонная трава \'Спортивная\'','Смесь трав для создания прочного газона',9.99,1,2,1,NULL,1,0.00),(3,'Лопата штыковая','Прочная стальная лопата для копки земли',19.99,2,1,1,NULL,2,0.00),(4,'Грабли веерные','Пластиковые грабли для уборки листьев',7.50,2,2,1,NULL,2,0.00),(5,'Комплексное удобрение \'Для роз\'','Удобрение для обильного цветения роз',4.99,3,3,1,NULL,1,0.00),(6,'Суперфосфат','Фосфорное удобрение для корнеобразования',3.20,3,3,1,NULL,1,0.00),(7,'Инсектицид \'Актара\'','Средство для борьбы с вредителями сада',8.99,4,4,1,NULL,4,0.00),(8,'Фунгицид \'Скор\'','Средство для защиты растений от грибковых заболеваний',11.75,4,4,1,NULL,4,0.00),(9,'Шланг садовый 1/2\"','Гибкий шланг для полива, 20 метров',15.99,5,5,1,NULL,5,0.00),(10,'Разбрызгиватель круговой','Разбрызгиватель для равномерного полива газона',12.50,5,5,1,NULL,5,0.00),(11,'Почвогрунт \'Универсальный\'','Готовый почвогрунт для рассады и посадки',6.99,6,6,1,NULL,3,0.00),(12,'Мульча древесная кора','Декоративная мульча для защиты почвы',5.00,6,6,1,NULL,3,0.00),(13,'Садовая фигурка \'Гном\'','Декоративная фигурка для сада',22.00,7,7,1,NULL,6,0.00),(14,'Светильник садовый на солнечной батарее','Светильник для освещения дорожек',18.75,7,7,1,NULL,6,0.00),(15,'Горшок для цветов керамический','Керамический горшок для комнатных растений',14.99,8,8,1,NULL,6,0.00),(16,'Кашпо подвесное пластиковое','Подвесное кашпо для балконов и террас',9.99,8,8,1,NULL,6,0.00),(17,'Фонарь садовый \'Сова\'','Фонарь для освещения сада, стилизованный под сову',28.00,9,7,1,NULL,6,0.00),(18,'Гирлянда светодиодная для сада','Гирлянда для создания атмосферного освещения',19.50,9,7,1,NULL,6,0.00),(19,'Перчатки садовые','Защитные перчатки для работы в саду',4.50,10,9,1,NULL,8,0.00),(20,'Маска защитная для лица','Защитная маска от пыли и вредителей',6.00,10,9,1,NULL,8,0.00),(21,'Семена Огурцов \'Муравей\'','Раннеспелый сорт огурцов для открытого грунта',1.75,1,1,1,NULL,1,0.00),(22,'Газонная трава \'Теневыносливая\'','Смесь трав для газонов в тени',10.99,1,2,1,NULL,1,0.00),(23,'Вилы садовые','Четырехзубые вилы для перекопки',24.99,2,1,1,NULL,2,0.00),(24,'Секатор садовый','Секатор для обрезки веток',11.99,2,1,1,NULL,2,0.00),(25,'Калийное удобрение','Для повышения урожайности и качества плодов',3.50,3,3,1,NULL,1,0.00),(26,'Удобрение для газона','Для поддержания здорового газона',5.00,3,3,1,NULL,1,0.00),(27,'Акарицид','Для борьбы с клещами',10.00,4,4,1,NULL,4,0.00),(28,'Ловушка для вредителей','Клеевая ловушка для вредителей',5.00,4,4,1,NULL,4,0.00),(29,'Таймер полива','Автоматический таймер для полива',29.99,5,5,1,NULL,5,0.00),(30,'Капельный полив','Система капельного полива',25.00,5,5,1,NULL,5,0.00),(31,'Почвогрунт для рассады','Для выращивания рассады',7.50,6,6,1,NULL,3,0.00),(32,'Щепа декоративная','Для мульчирования',6.00,6,6,1,NULL,3,0.00),(33,'Садовый гном (большой)','Декоративная садовая фигура',30.00,7,7,1,NULL,6,0.00),(34,'Светодиодный прожектор','Для освещения сада',35.00,7,7,1,NULL,6,0.00),(35,'Горшок для орхидей','Прозрачный горшок для орхидей',18.00,8,8,1,NULL,6,0.00),(36,'Набор кашпо','Набор из трех кашпо',20.00,8,8,1,NULL,6,0.00),(37,'Фонарь-шар','Садовый фонарь в форме шара',32.00,9,7,1,NULL,6,0.00),(38,'Светодиодная лента для сада','Для подсветки дорожек',22.00,9,7,1,NULL,6,0.00),(39,'Рабочие перчатки','Для защиты рук при работах',5.00,10,9,1,NULL,8,0.00),(40,'Респиратор','Для защиты от пыли',7.00,10,9,1,NULL,8,0.00),(41,'Семена Кабачков \'Зебра\'','Раннеспелый сорт кабачков',1.50,1,1,1,NULL,1,0.00),(42,'Газонная трава \'Универсальная\'','Трава для различных условий',10.00,1,2,1,NULL,1,0.00),(43,'Мотыга','Для рыхления почвы',15.00,2,1,1,NULL,2,0.00),(44,'Кусторез','Для обрезки кустов',20.00,2,1,1,NULL,2,0.00),(45,'Азотное удобрение','Для быстрого роста',4.00,3,3,1,NULL,1,0.00),(46,'Подкормка для цветов','Для обильного цветения',6.00,3,3,1,NULL,1,0.00),(47,'Средство от муравьев','Для борьбы с муравьями в саду',9.00,4,4,1,NULL,4,0.00),(48,'Ловушка для слизней','Для защиты от слизней',6.00,4,4,1,NULL,4,0.00),(49,'Шланг поливочный','Для полива',16.00,5,5,1,NULL,5,0.00),(50,'Дождеватель','Для полива',13.00,5,5,1,NULL,5,0.00);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(50) NOT NULL,
  `descript` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`role_id`),
  UNIQUE KEY `role_name` (`role_name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Администратор','Админ_расписать позже'),(2,'Продавец','за кассой стоит');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `suppliers_id` int NOT NULL AUTO_INCREMENT,
  `supplier_name` varchar(255) NOT NULL,
  `descript` text,
  `email` varchar(255) DEFAULT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `legal_address` varchar(255) DEFAULT NULL,
  `registration_number_inn` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`suppliers_id`),
  UNIQUE KEY `registration_number_inn` (`registration_number_inn`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'ООО \"АгроСнаб\"','Поставщик семян и удобрений','info@agrosnab.ru','+7 (495) 777-88-99','г. Москва, ул. Пушкина, д. 10','123456789012'),(2,'ИП Иванов И.И.','Производитель садового инвентаря','ivanov@mail.ru','+7 (916) 111-22-33','г. Санкт-Петербург, ул. Невский проспект, д. 20','345678901234'),(3,'ООО \"Зеленый Дом\"','Оптовая продажа комнатных растений','opt@zelenyi-dom.ru','+7 (499) 222-33-44','г. Екатеринбург, ул. Малышева, д. 30','567890123456'),(4,'ООО \"ЭкоУдобрения\"','Поставщик органических удобрений','eco@udobrenia.ru','+7 (812) 333-44-55','г. Казань, ул. Баумана, д. 40','789012345678'),(5,'ООО \"СадТехника\"','Импорт садового оборудования','import@sadtehnika.ru','+7 (473) 444-55-66','г. Воронеж, ул. Революции 1905 года, д. 50','901234567890'),(6,'ООО \"Цветочный Рай\"','Поставщик цветочной рассады','info@cvetochnyi-rai.ru','+7 (863) 555-66-77','г. Ростов-на-Дону, ул. Большая Садовая, д. 60','112233445566'),(7,'ИП Петров П.П.','Производитель теплиц и парников','petrov@mail.ru','+7 (926) 666-77-88','г. Новосибирск, ул. Красный проспект, д. 70','223344556677'),(8,'ООО \"АкваСтрой\"','Поставщик систем полива','aqua@stroi.ru','+7 (383) 777-88-99','г. Омск, ул. Ленина, д. 80','334455667788'),(9,'ООО \"ЛандшафтДизайн\"','Услуги ландшафтного дизайна','design@landshaft.ru','+7 (846) 888-99-00','г. Самара, ул. Куйбышева, д. 90','445566778899'),(10,'ООО \"ЗащитаРастений\"','Средства защиты растений от вредителей','zashita@rastenii.ru','+7 (499) 999-00-11','г. Уфа, ул. Проспект Октября, д. 100','556677889900');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `users_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role_id` int DEFAULT NULL,
  `last_login_date` datetime DEFAULT NULL,
  `notes` text,
  PRIMARY KEY (`users_id`),
  UNIQUE KEY `username` (`username`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','$2y$10$ROVhvYbEzFwbP7vEre1T1u/rYnLE95Oa6y9V5UaV2k984Y3Lq4R3i',1,'2025-02-20 21:30:29','Administrator account'),(2,'john_doe','$2y$10$vVVJ1q5zS6VZ7x8f4sJ06uuX0n4o/c75K9d.jVwK3V00d9rU0u8q',2,'2025-02-19 21:30:29','Regular user'),(3,'jane_smith','$2y$10$W9kP4v2a.s4X8r9f0tQ3Ou/o.J4i0a8Q3q2W8sI0d6g17g0h5kL6',2,'2025-02-18 21:30:29','New user'),(4,'peter_jones','$2y$10$V1aG4p6c3Q2k9L0b6U5a8.Q0b8W1y3X1z5v6L3k8D4.e4H5t2j7m',2,'2025-02-17 21:30:29','User with gardening experience'),(5,'mary_white','$2y$10$v0U.j6v2p1t9z4f.j4W5O0t3y2P4g.e8i6f.g8h.i9j0k7l8m9',2,'2025-02-16 21:30:29','Interested in organic gardening'),(6,'david_brown','$2y$10$j9n.a2r6g3H4j8f.z8R1p0x0o7y.i1z2v4c6b8d.e1f2g3h4i',2,'2025-02-15 21:30:29','User focusing on landscaping'),(7,'susan_green','$2y$10$n2k3j5h7i9l1.z1x3c5v7b9a0s8d6f.g2h4j6k8l0m1n2',2,'2025-02-14 21:30:29','User interested in herbs'),(8,'robert_gray','$2y$10$p4o5n7m9q1r3s5t7u9w1x3y5z7a9c1b3d5e7f9g1h3i5j7',2,'2025-02-13 21:30:29','User specializing in roses'),(9,'linda_black','$2y$10$r6q8p0s2t4u6v8w0y2z4a6b8c0d2e4f6g8h0i2j4k6l8m',2,'2025-02-12 21:30:29','User interested in vegetable gardening'),(10,'tom_orange','$2y$10$s8t0v2w4x6y8z0a2b4c6d8e0f2g4h6i8j0k2l4m6n8o0p',2,'2025-02-11 21:30:29','User with experience in fruit trees');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-20 22:10:48
