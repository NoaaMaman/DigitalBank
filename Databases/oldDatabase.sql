-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: db_bank
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account` (
  `account_id` int NOT NULL,
  `customer_code` int DEFAULT NULL,
  `account_type` varchar(45) DEFAULT NULL,
  `account_balance` decimal(10,0) DEFAULT NULL,
  `total_commision` decimal(10,0) DEFAULT NULL,
  `account_status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`account_id`),
  KEY `customer_id_idx` (`customer_code`),
  CONSTRAINT `customer_code` FOREIGN KEY (`customer_code`) REFERENCES `customer` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (555,123456,'890',1000,23,'plus'),(567,121314,'456',-5000,500,'minus'),(987,978621,'890',20000,900,'plus');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account_types`
--

DROP TABLE IF EXISTS `account_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account_types` (
  `account_type_id` int NOT NULL,
  `account_type_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`account_type_id`),
  KEY `account_type_id_idx` (`account_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_types`
--

LOCK TABLES `account_types` WRITE;
/*!40000 ALTER TABLE `account_types` DISABLE KEYS */;
INSERT INTO `account_types` VALUES (456,'couples'),(556,'18+'),(890,'business');
/*!40000 ALTER TABLE `account_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `another_bank`
--

DROP TABLE IF EXISTS `another_bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `another_bank` (
  `bank_id` int NOT NULL,
  `bank_name` varchar(45) DEFAULT NULL,
  `connection` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`bank_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `another_bank`
--

LOCK TABLES `another_bank` WRITE;
/*!40000 ALTER TABLE `another_bank` DISABLE KEYS */;
INSERT INTO `another_bank` VALUES (980,'discont','internal'),(999,'leumi','external');
/*!40000 ALTER TABLE `another_bank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch`
--

DROP TABLE IF EXISTS `branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branch` (
  `branch_id` int NOT NULL,
  `branch_name` varchar(45) DEFAULT NULL,
  `adress` text,
  `district` varchar(45) DEFAULT NULL,
  `levelVU` int DEFAULT NULL,
  PRIMARY KEY (`branch_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch`
--

LOCK TABLES `branch` WRITE;
/*!40000 ALTER TABLE `branch` DISABLE KEYS */;
INSERT INTO `branch` VALUES (542,'rosh-pina1','rosh pina brosh 13','north',2),(778,'natania-3','big poleg 13','center',7),(876,'kiryat shemona','atamar 778','north',5),(900,'eilat','amore 90','south',3),(967,'tel-aviv2','arlozorov 3','center',8);
/*!40000 ALTER TABLE `branch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capital_market`
--

DROP TABLE IF EXISTS `capital_market`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `capital_market` (
  `capital_id` int NOT NULL,
  `account_id` int DEFAULT NULL,
  `capitla_type` varchar(45) DEFAULT NULL,
  `capital_amount` decimal(10,0) DEFAULT NULL,
  `theAdviser` int DEFAULT NULL,
  `stock_code` int DEFAULT NULL,
  PRIMARY KEY (`capital_id`),
  KEY `stock_code_idx` (`stock_code`),
  CONSTRAINT `stock_code` FOREIGN KEY (`stock_code`) REFERENCES `stock` (`stock_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capital_market`
--

LOCK TABLES `capital_market` WRITE;
/*!40000 ALTER TABLE `capital_market` DISABLE KEYS */;
INSERT INTO `capital_market` VALUES (333,987,'business_marketing',700,127,1000),(789,555,'private_marketing',450,990,135);
/*!40000 ALTER TABLE `capital_market` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `card company`
--

DROP TABLE IF EXISTS `card company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `card company` (
  `company_id` int NOT NULL,
  `name_company` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`company_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card company`
--

LOCK TABLES `card company` WRITE;
/*!40000 ALTER TABLE `card company` DISABLE KEYS */;
INSERT INTO `card company` VALUES (34,'isracart'),(88,'cal'),(90,'american expres'),(92,'viza');
/*!40000 ALTER TABLE `card company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashier`
--

DROP TABLE IF EXISTS `cashier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cashier` (
  `transaction_num` int NOT NULL,
  `request_num` int NOT NULL,
  `status_cahsier` varchar(45) DEFAULT NULL,
  KEY `transaction_num_idx` (`transaction_num`),
  KEY `request_num_idx` (`request_num`),
  CONSTRAINT `request_num` FOREIGN KEY (`request_num`) REFERENCES `request` (`request_id`),
  CONSTRAINT `transaction_num` FOREIGN KEY (`transaction_num`) REFERENCES `transaction` (`transaction_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashier`
--

LOCK TABLES `cashier` WRITE;
/*!40000 ALTER TABLE `cashier` DISABLE KEYS */;
/*!40000 ALTER TABLE `cashier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cats`
--

DROP TABLE IF EXISTS `cats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cats` (
  `cat_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `breed` varchar(100) DEFAULT NULL,
  `age` int DEFAULT NULL,
  PRIMARY KEY (`cat_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cats`
--

LOCK TABLES `cats` WRITE;
/*!40000 ALTER TABLE `cats` DISABLE KEYS */;
INSERT INTO `cats` VALUES (1,'Ringo','Tabby',4),(2,'Cindy','Maine Coon',10),(3,'Dumbledore','Maine Coon',11),(4,'Egg','Persian',4),(5,'Misty','Tabby',13),(6,'George Michael','Ragdoll',9),(7,'Jackson','Sphynx',7);
/*!40000 ALTER TABLE `cats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit_card`
--

DROP TABLE IF EXISTS `credit_card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `credit_card` (
  `card_id` int NOT NULL,
  `account_id` int DEFAULT NULL,
  `upper_boud` decimal(10,0) DEFAULT NULL,
  `credit_ratingVU` decimal(10,0) DEFAULT NULL,
  `credit_balanceVU` decimal(10,0) DEFAULT NULL,
  `credit_card_type` varchar(45) DEFAULT NULL,
  `external_company` int DEFAULT NULL,
  PRIMARY KEY (`card_id`),
  KEY `ex_company_idx` (`external_company`),
  KEY `ac_code_idx` (`account_id`),
  CONSTRAINT `ac_code` FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`),
  CONSTRAINT `ex_company` FOREIGN KEY (`external_company`) REFERENCES `card company` (`company_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit_card`
--

LOCK TABLES `credit_card` WRITE;
/*!40000 ALTER TABLE `credit_card` DISABLE KEYS */;
INSERT INTO `credit_card` VALUES (111,555,15000,30,2500,'direct',34),(122,567,5000,20,5000,'debit',88),(666,987,2500,80,2000,'direct',90);
/*!40000 ALTER TABLE `credit_card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `customer_id` int NOT NULL,
  `fist_name` varchar(50) DEFAULT NULL,
  `secons_name` varchar(50) DEFAULT NULL,
  `age` int DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `adress` varchar(300) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `email` varchar(320) DEFAULT NULL,
  `salary_customer` decimal(10,0) DEFAULT NULL,
  `personal_teller_id` int DEFAULT NULL,
  `family_status` varchar(45) DEFAULT NULL,
  `civil status` varchar(45) DEFAULT NULL,
  `economic_status` varchar(45) DEFAULT NULL,
  `homeBranch` int DEFAULT NULL,
  PRIMARY KEY (`customer_id`),
  KEY `branch_id_idx` (`homeBranch`),
  CONSTRAINT `branch_id` FOREIGN KEY (`homeBranch`) REFERENCES `branch` (`branch_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (121314,'ploni','almoni',59,'052-7808473','Tel-Aviv evenGabirol 13','1963-05-09','jmmuller@outlook.com',10000,9976,'married','on-condition','non-stable',967),(123456,'noaa','maman',19,'053-2795067','Rosh-pina hirus 12','2002-09-13','noaamaman325158@gmail.com',0,4567,'single','no-criminal','stable',542),(213141,'plona','almoni',50,'052-9908473','Tel-Aviv evenGabirol 13','1972-08-08','jplonar@outlook.com',7000,9976,'married','non-criminal','non-stable',967),(978621,'sagit','maman',24,'058-8395739','eilat hanavie 78','1997-12-08','sagiemam324@gmail.com',15000,8080,'in-relationsip','on condition','stable',900);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deposite_account`
--

DROP TABLE IF EXISTS `deposite_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deposite_account` (
  `deposite_id` int NOT NULL,
  `account_id` int DEFAULT NULL,
  `deposite_account_type` int DEFAULT NULL,
  `deposite_balance` decimal(10,0) DEFAULT NULL,
  `deposite_status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`deposite_id`),
  KEY `account_code_idx` (`account_id`),
  KEY `deposite_account_type_idx` (`deposite_account_type`),
  CONSTRAINT `account_code` FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deposite_account`
--

LOCK TABLES `deposite_account` WRITE;
/*!40000 ALTER TABLE `deposite_account` DISABLE KEYS */;
INSERT INTO `deposite_account` VALUES (5556,555,34,1800,'block'),(7878,567,98,12000,'dynamic-block'),(9999,987,90,500,'block');
/*!40000 ALTER TABLE `deposite_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `employee_id` int NOT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `second_name` varchar(45) DEFAULT NULL,
  `salary_employee` decimal(10,0) DEFAULT NULL,
  `adress` text,
  `birth_date` date DEFAULT NULL,
  `employee_position` int DEFAULT NULL,
  `hire_date` date DEFAULT NULL,
  `isAdviser` varchar(4) DEFAULT NULL,
  `email` varchar(320) DEFAULT NULL,
  `specizlization` int DEFAULT NULL,
  `branch_number` int DEFAULT NULL,
  PRIMARY KEY (`employee_id`),
  KEY `position_code_idx` (`employee_position`),
  KEY `branch_id_idx` (`branch_number`),
  KEY `specialization_idx` (`specizlization`),
  KEY `branch_code_idx` (`branch_number`),
  KEY `specialization_code_idx` (`specizlization`),
  CONSTRAINT `branch_number` FOREIGN KEY (`branch_number`) REFERENCES `branch` (`branch_id`),
  CONSTRAINT `employee_position` FOREIGN KEY (`employee_position`) REFERENCES `types_and_salary` (`employee_position_code`),
  CONSTRAINT `spacialization` FOREIGN KEY (`specizlization`) REFERENCES `specialization_type` (`special_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (127,'shlomi','hameiri',30000,'eilat nir 67','1885-12-01',7,'2019-03-02','no','msdjusbburgo@aol.com',2,900),(1019,'shlomit','cohen',25000,'hagoshrim atehena 4','1889-11-09',6,'2002-06-06','yes','slomit@outlook.com',2,542),(3333,'shlomi','hameiri',20000,'dafna yuval 5','1880-05-05',7,'2021-02-03','no','shlomiHa@gmail.com',2,900),(4567,'Yosi ','Smueli',10000,'Hazor Gefen 3','1990-07-30',3,'2000-06-01','Yes','jgmyers@gmail.com',1,542),(8080,'orly','yefet',1000000,'hadera smuel 2','1985-11-09',10,'2010-05-16','yes','orlyYefet123@gmail.com',3,900),(9090,'sagie','maman',20000,'eilat anavie 19','1996-12-07',4,'2020-01-22','no','sagi553@gmail.com',2,967),(9976,'avi','maman',15000,'zefat yafo 18','1885-12-01',5,'2002-03-02','yes','mfburgo@aol.com',5,542);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `interest`
--

DROP TABLE IF EXISTS `interest`;
/*!50001 DROP VIEW IF EXISTS `interest`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `interest` AS SELECT 
 1 AS `equity`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `interest_info`
--

DROP TABLE IF EXISTS `interest_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `interest_info` (
  `interest_id` int NOT NULL,
  `equity` int NOT NULL,
  `credit_rating` decimal(10,0) DEFAULT NULL,
  `taxes_per_month` decimal(10,0) DEFAULT NULL,
  `customer_number` int DEFAULT NULL,
  PRIMARY KEY (`interest_id`),
  KEY `customer_number_idx` (`customer_number`),
  CONSTRAINT `customer_number` FOREIGN KEY (`customer_number`) REFERENCES `customer` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interest_info`
--

LOCK TABLES `interest_info` WRITE;
/*!40000 ALTER TABLE `interest_info` DISABLE KEYS */;
INSERT INTO `interest_info` VALUES (111,2,30,3000,121314),(123,1,2,2101,978621),(565,0,0,0,123456);
/*!40000 ALTER TABLE `interest_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loan`
--

DROP TABLE IF EXISTS `loan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loan` (
  `loan_id` int NOT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `account_id` int DEFAULT NULL,
  `loan_interest_percent` decimal(10,0) DEFAULT NULL,
  `cost_for_month` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`loan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loan`
--

LOCK TABLES `loan` WRITE;
/*!40000 ALTER TABLE `loan` DISABLE KEYS */;
INSERT INTO `loan` VALUES (993,1,555,30,5000);
/*!40000 ALTER TABLE `loan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loan_type`
--

DROP TABLE IF EXISTS `loan_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loan_type` (
  `loan_id` int NOT NULL,
  `loan_type` varchar(45) DEFAULT NULL,
  `numOfPayments` int DEFAULT NULL,
  PRIMARY KEY (`loan_id`),
  CONSTRAINT `loan_id` FOREIGN KEY (`loan_id`) REFERENCES `loan` (`loan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loan_type`
--

LOCK TABLES `loan_type` WRITE;
/*!40000 ALTER TABLE `loan_type` DISABLE KEYS */;
INSERT INTO `loan_type` VALUES (993,'mortgage',10);
/*!40000 ALTER TABLE `loan_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mortgage`
--

DROP TABLE IF EXISTS `mortgage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mortgage` (
  `mortgage_id` int NOT NULL,
  `account_id` int DEFAULT NULL,
  `theAdviser` int DEFAULT NULL,
  `actual_range_years` int DEFAULT NULL,
  `asset` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`mortgage_id`),
  KEY `account_id_idx` (`account_id`),
  KEY `theAdviser_idx` (`theAdviser`),
  CONSTRAINT `account_id` FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`),
  CONSTRAINT `theAdviser` FOREIGN KEY (`theAdviser`) REFERENCES `employee` (`employee_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mortgage`
--

LOCK TABLES `mortgage` WRITE;
/*!40000 ALTER TABLE `mortgage` DISABLE KEYS */;
INSERT INTO `mortgage` VALUES (111,555,9976,10,'ground_house'),(556,567,1019,30,'restaurant');
/*!40000 ALTER TABLE `mortgage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offers`
--

DROP TABLE IF EXISTS `offers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `offers` (
  `offer_id` int NOT NULL,
  `status_offer` varchar(45) DEFAULT NULL,
  `cutomer_iden` int DEFAULT NULL,
  `offer_type` varchar(45) DEFAULT NULL,
  `offer_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`offer_id`),
  KEY `customer_iden_idx` (`cutomer_iden`),
  CONSTRAINT `customer_iden` FOREIGN KEY (`cutomer_iden`) REFERENCES `customer` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offers`
--

LOCK TABLES `offers` WRITE;
/*!40000 ALTER TABLE `offers` DISABLE KEYS */;
INSERT INTO `offers` VALUES (111,'reject',213141,'credit card','extend upper bound ');
/*!40000 ALTER TABLE `offers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persons`
--

DROP TABLE IF EXISTS `persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persons` (
  `ID` int NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) DEFAULT NULL,
  `Age` int DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persons`
--

LOCK TABLES `persons` WRITE;
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report_branch`
--

DROP TABLE IF EXISTS `report_branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `report_branch` (
  `report_branch_num` int NOT NULL,
  `branch_iden` int DEFAULT NULL,
  PRIMARY KEY (`report_branch_num`),
  KEY `report_branch_num_idx` (`report_branch_num`),
  KEY `branch_iden_idx` (`branch_iden`),
  CONSTRAINT `branch_iden` FOREIGN KEY (`branch_iden`) REFERENCES `branch` (`branch_id`),
  CONSTRAINT `report_branch_num` FOREIGN KEY (`report_branch_num`) REFERENCES `reports` (`report_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report_branch`
--

LOCK TABLES `report_branch` WRITE;
/*!40000 ALTER TABLE `report_branch` DISABLE KEYS */;
INSERT INTO `report_branch` VALUES (333,900),(111,967);
/*!40000 ALTER TABLE `report_branch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report_customer`
--

DROP TABLE IF EXISTS `report_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `report_customer` (
  `report_num` int NOT NULL,
  `account` int DEFAULT NULL,
  PRIMARY KEY (`report_num`),
  KEY `report_cust_num_idx` (`report_num`),
  KEY `account_idx` (`account`),
  CONSTRAINT `account` FOREIGN KEY (`account`) REFERENCES `account` (`account_id`),
  CONSTRAINT `report_cust_num` FOREIGN KEY (`report_num`) REFERENCES `reports` (`report_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report_customer`
--

LOCK TABLES `report_customer` WRITE;
/*!40000 ALTER TABLE `report_customer` DISABLE KEYS */;
INSERT INTO `report_customer` VALUES (222,555),(444,987);
/*!40000 ALTER TABLE `report_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reports`
--

DROP TABLE IF EXISTS `reports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reports` (
  `report_id` int NOT NULL,
  `report_type` varchar(55) DEFAULT NULL,
  `report_dest` varchar(45) DEFAULT NULL,
  `status_report` varchar(45) DEFAULT NULL,
  `report_source` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`report_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reports`
--

LOCK TABLES `reports` WRITE;
/*!40000 ALTER TABLE `reports` DISABLE KEYS */;
INSERT INTO `reports` VALUES (111,'branch','tel-Aviv branch','wait','main Bank'),(222,'customer','noaa maman','receivied','homeBranch'),(333,'branch','eilat branch','non-received','rosh pina branch'),(444,'customer','plona alomoni','wrong-details','mainBank');
/*!40000 ALTER TABLE `reports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `request` (
  `request_id` int NOT NULL,
  `status_request` varchar(45) DEFAULT NULL,
  `cust_code` int DEFAULT NULL,
  `request_type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`request_id`),
  KEY `cust_code_idx` (`cust_code`),
  CONSTRAINT `cust_code` FOREIGN KEY (`cust_code`) REFERENCES `customer` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request`
--

LOCK TABLES `request` WRITE;
/*!40000 ALTER TABLE `request` DISABLE KEYS */;
INSERT INTO `request` VALUES (126,'reject',123456,'loan_request'),(880,'execute',123456,'call me '),(945,'under treatment',121314,'cancel last activity');
/*!40000 ALTER TABLE `request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `salaryemployee`
--

DROP TABLE IF EXISTS `salaryemployee`;
/*!50001 DROP VIEW IF EXISTS `salaryemployee`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `salaryemployee` AS SELECT 
 1 AS `salary_employee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `secure`
--

DROP TABLE IF EXISTS `secure`;
/*!50001 DROP VIEW IF EXISTS `secure`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `secure` AS SELECT 
 1 AS `secure_id`,
 1 AS `usernameVU`,
 1 AS `passwordVU`,
 1 AS `customer_id`,
 1 AS `identifiler1_motherNameVU`,
 1 AS `identifiler2_birthDateVU`,
 1 AS `identifiler3_colorVU`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `security_details`
--

DROP TABLE IF EXISTS `security_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `security_details` (
  `secure_id` int NOT NULL,
  `usernameVU` varchar(256) DEFAULT NULL,
  `passwordVU` varchar(127) DEFAULT NULL,
  `customer_id` int DEFAULT NULL,
  `identifiler1_motherNameVU` varchar(45) DEFAULT NULL,
  `identifiler2_birthDateVU` date DEFAULT NULL,
  `identifiler3_colorVU` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`secure_id`),
  KEY `customer_id_idx` (`customer_id`),
  CONSTRAINT `customer_id` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `security_details`
--

LOCK TABLES `security_details` WRITE;
/*!40000 ALTER TABLE `security_details` DISABLE KEYS */;
INSERT INTO `security_details` VALUES (135,'noaaMaman1309','maman1213@',123456,'Rachel','2002-09-13','red'),(136,'PloniAlmoni134','Ploni@#$',121314,'plomona','1963-05-09','light-green'),(139,'plonalmona123','Almona11@',213141,'iris','1830-06-12','bordo'),(222,'sagitharosh1213','sagit123#2',978621,'hagit','1997-12-08','grey');
/*!40000 ALTER TABLE `security_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specialization_type`
--

DROP TABLE IF EXISTS `specialization_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specialization_type` (
  `special_id` int NOT NULL,
  `special_name` varchar(45) DEFAULT NULL,
  `special_type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`special_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specialization_type`
--

LOCK TABLES `specialization_type` WRITE;
/*!40000 ALTER TABLE `specialization_type` DISABLE KEYS */;
INSERT INTO `specialization_type` VALUES (1,'economic','general'),(2,'capital market marketing','capital market'),(3,'economic and investment','general'),(4,'credit-cards expert','credit-cards'),(5,'mortgage','loans');
/*!40000 ALTER TABLE `specialization_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `stock_id` int NOT NULL,
  `stock_name` varchar(45) DEFAULT NULL,
  `typeof-stock` varchar(45) DEFAULT NULL,
  `price_per_stock` decimal(10,0) DEFAULT NULL,
  `status_stock` varchar(45) DEFAULT NULL,
  `status_precentage` decimal(10,0) DEFAULT NULL,
  `stopLose` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`stock_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES (111,'tesla','cars',702,'growing',2,500),(135,'apple_tech','tech',90,'growing',30,60),(1000,'bio_tech','medicine',500,'extinguished',12,450);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction` (
  `transaction_id` int NOT NULL,
  `account_id` int DEFAULT NULL,
  `total_transaction_priceVU` decimal(10,0) DEFAULT NULL,
  `total_transaction_commision` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`transaction_id`),
  KEY `account_num_idx` (`account_id`),
  CONSTRAINT `account_num` FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction`
--

LOCK TABLES `transaction` WRITE;
/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
INSERT INTO `transaction` VALUES (1,555,1000,15),(2,555,450,10),(9,555,500,2),(10,987,20000,13);
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction details`
--

DROP TABLE IF EXISTS `transaction details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction details` (
  `transaction_id` int NOT NULL,
  `transaction_type` varchar(45) DEFAULT NULL,
  `transaction_name` varchar(45) DEFAULT NULL,
  `amount_specifies` decimal(10,0) DEFAULT NULL,
  `commision_per_transaction` decimal(10,0) DEFAULT NULL,
  `time_transaction` datetime DEFAULT NULL,
  PRIMARY KEY (`transaction_id`),
  CONSTRAINT `transaction_id` FOREIGN KEY (`transaction_id`) REFERENCES `transaction` (`transaction_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction details`
--

LOCK TABLES `transaction details` WRITE;
/*!40000 ALTER TABLE `transaction details` DISABLE KEYS */;
INSERT INTO `transaction details` VALUES (1,'Automated_teller_activities','deposite_money',100,2,'2022-05-12 13:23:45'),(2,'marketing','stock investment',450,10,'2021-04-11 13:05:50'),(9,'transfering','transfer_fund',500,3,'2022-04-11 12:05:00');
/*!40000 ALTER TABLE `transaction details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transfer_funds`
--

DROP TABLE IF EXISTS `transfer_funds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transfer_funds` (
  `transfer_id` int NOT NULL,
  `dest` varchar(45) DEFAULT NULL,
  `source` varchar(45) DEFAULT NULL,
  `executive_id` int DEFAULT NULL,
  `bank_code` int DEFAULT NULL,
  PRIMARY KEY (`transfer_id`),
  KEY `executive_idx` (`executive_id`),
  KEY `bank_code_idx` (`bank_code`),
  CONSTRAINT `bank_code` FOREIGN KEY (`bank_code`) REFERENCES `another_bank` (`bank_id`),
  CONSTRAINT `executive_id` FOREIGN KEY (`executive_id`) REFERENCES `account` (`account_id`),
  CONSTRAINT `transfer_id` FOREIGN KEY (`transfer_id`) REFERENCES `transaction` (`transaction_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transfer_funds`
--

LOCK TABLES `transfer_funds` WRITE;
/*!40000 ALTER TABLE `transfer_funds` DISABLE KEYS */;
INSERT INTO `transfer_funds` VALUES (9,'thisBank','thisBank',555,980),(10,'anotherBank','thisBank',987,999);
/*!40000 ALTER TABLE `transfer_funds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `twitts`
--

DROP TABLE IF EXISTS `twitts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `twitts` (
  `username` varchar(15) DEFAULT NULL,
  `content` varchar(140) DEFAULT NULL,
  `favorites` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `twitts`
--

LOCK TABLES `twitts` WRITE;
/*!40000 ALTER TABLE `twitts` DISABLE KEYS */;
/*!40000 ALTER TABLE `twitts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `types salary`
--

DROP TABLE IF EXISTS `types salary`;
/*!50001 DROP VIEW IF EXISTS `types salary`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `types salary` AS SELECT 
 1 AS `salary_for_type`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `types_and_salary`
--

DROP TABLE IF EXISTS `types_and_salary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `types_and_salary` (
  `employee_position_code` int NOT NULL,
  `name_pf_position` varchar(45) DEFAULT NULL,
  `salary_for_type` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`employee_position_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types_and_salary`
--

LOCK TABLES `types_and_salary` WRITE;
/*!40000 ALTER TABLE `types_and_salary` DISABLE KEYS */;
INSERT INTO `types_and_salary` VALUES (3,'economic_analyse',9000),(4,'junior_marketing',10550),(5,'mortgage_expert',14000),(6,'motgage_senior',19000),(7,'senior_marketing_business',30000),(10,'senior_adviser_aconomic',500000);
/*!40000 ALTER TABLE `types_and_salary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `interest`
--

/*!50001 DROP VIEW IF EXISTS `interest`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `interest` AS select `interest_info`.`equity` AS `equity` from `interest_info` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `salaryemployee`
--

/*!50001 DROP VIEW IF EXISTS `salaryemployee`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `salaryemployee` AS select `employee`.`salary_employee` AS `salary_employee` from `employee` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `secure`
--

/*!50001 DROP VIEW IF EXISTS `secure`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `secure` AS select `security_details`.`secure_id` AS `secure_id`,`security_details`.`usernameVU` AS `usernameVU`,`security_details`.`passwordVU` AS `passwordVU`,`security_details`.`customer_id` AS `customer_id`,`security_details`.`identifiler1_motherNameVU` AS `identifiler1_motherNameVU`,`security_details`.`identifiler2_birthDateVU` AS `identifiler2_birthDateVU`,`security_details`.`identifiler3_colorVU` AS `identifiler3_colorVU` from `security_details` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `types salary`
--

/*!50001 DROP VIEW IF EXISTS `types salary`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `types salary` AS select `types_and_salary`.`salary_for_type` AS `salary_for_type` from `types_and_salary` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-26 15:22:14
