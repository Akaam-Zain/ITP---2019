-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: inventorymgt
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `regId` int(11) NOT NULL,
  `fname` text,
  `lname` text,
  `email` text,
  `password_` varchar(255) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `ocp` text,
  `weight_` int(11) DEFAULT NULL,
  `height` double DEFAULT NULL,
  `phone` text,
  `address` text,
  `shedule` text,
  `d_plan` text,
  `pay_type` text,
  `gender` text,
  `img_path` text,
  PRIMARY KEY (`regId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (0,'Akaam','Zain','akaamzain@hotmail.com','1202',21,NULL,66,5.7,'0770161414','419,Kandy rd, Kandy','D30','L2','1 Month','Male','~/image/male.png'),(17,'Dushan','Dewasurendra','dushan@gmail.com','123',24,'Virtusa',50,5,'764519893','N0.08, Dewanmini, Gammedapitiya,, Hakmana.','D45','L1','1 Month','Male','~/image/male.png'),(18,'Hansani','Yashoda','hansani@gmail.com','123',22,'Student',40,4.8,'0773245667','Matara','D30','L1','1 Month','Female','~/image/female.png'),(20,'Lashini','Dewasurendra','lashini@gmail.com','123',30,'Singer PLC',55,5,'764519893','negambo','D30','L1','1 Month','Female','~/image/female.png'),(21,'Eranda','Withange','eranda@gmail.com','123',23,'Employee',60,5,'0773245667','Negambo',NULL,NULL,'1 Month','Male','~/image/female.png'),(24,'dilki','Jayasooriya','dilki@gmail.com','456',23,'Student',34,5.3,'0712234566','Weligama. Matara','45 days','Level 1','1 Month','Male','~/image/dilki_jayasooriya190401407.jpg');
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

-- Dump completed on 2019-09-08 19:28:08
