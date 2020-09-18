
CREATE DATABASE  IF NOT EXISTS `attendance management system` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `system`;
-- USE `attendance management system`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: attendance management system
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `classroom_info`
--

DROP TABLE IF EXISTS `classroom_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classroom_info` (
  `classroom_id` int NOT NULL,
  PRIMARY KEY (`classroom_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classroom_info`
--

LOCK TABLES `classroom_info` WRITE;
/*!40000 ALTER TABLE `classroom_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `classroom_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course` (
  `course_id` int NOT NULL,
  `course_name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`course_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leave_application`
--

DROP TABLE IF EXISTS `leave_application`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leave_application` (
  `course_id` int NOT NULL,
  `class_date` varchar(15) NOT NULL,
  `s_num` int NOT NULL,
  `ask_for_leave_reason` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`course_id`,`class_date`,`s_num`),
  KEY `leave_s_num_idx` (`s_num`),
  CONSTRAINT `leave_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`course_id`),
  CONSTRAINT `leave_s_num` FOREIGN KEY (`s_num`) REFERENCES `student` (`S_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leave_application`
--

LOCK TABLES `leave_application` WRITE;
/*!40000 ALTER TABLE `leave_application` DISABLE KEYS */;
/*!40000 ALTER TABLE `leave_application` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permissions_info`
--

DROP TABLE IF EXISTS `permissions_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permissions_info` (
  `ID` varchar(20) NOT NULL,
  `nser_level` int DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permissions_info`
--

LOCK TABLES `permissions_info` WRITE;
/*!40000 ALTER TABLE `permissions_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `permissions_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `register`
--

DROP TABLE IF EXISTS `register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `register` (
  `attendance_sheet_id` int NOT NULL,
  `course_id` int DEFAULT NULL,
  `class_date` varchar(15) DEFAULT NULL,
  `s_num` int NOT NULL,
  `sign_in_situation` varchar(10) DEFAULT NULL,
  `sign_in_time` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`attendance_sheet_id`,`s_num`),
  KEY `register_course_id_idx` (`course_id`),
  KEY `register_s_num_idx` (`s_num`),
  CONSTRAINT `register_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`course_id`),
  CONSTRAINT `register_s_num` FOREIGN KEY (`s_num`) REFERENCES `student` (`S_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `register`
--

LOCK TABLES `register` WRITE;
/*!40000 ALTER TABLE `register` DISABLE KEYS */;
/*!40000 ALTER TABLE `register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `section`
--

DROP TABLE IF EXISTS `section`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `section` (
  `course_id` int NOT NULL,
  `sec_id` int NOT NULL,
  `semester` varchar(10) NOT NULL,
  `year` int NOT NULL,
  `time_slot_id` int DEFAULT NULL,
  `classroom_id` int DEFAULT NULL,
  PRIMARY KEY (`course_id`,`sec_id`,`year`,`semester`),
  KEY `section_classroom_idx` (`classroom_id`),
  CONSTRAINT `section_classroom_id` FOREIGN KEY (`classroom_id`) REFERENCES `classroom_info` (`classroom_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `section`
--

LOCK TABLES `section` WRITE;
/*!40000 ALTER TABLE `section` DISABLE KEYS */;
/*!40000 ALTER TABLE `section` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `select_sec`
--

DROP TABLE IF EXISTS `select_sec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `select_sec` (
  `select_id` int NOT NULL,
  `S_num` int DEFAULT NULL,
  `S_name` varchar(45) NOT NULL,
  `course_id` int DEFAULT NULL,
  `course_name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`select_id`),
  KEY `slect_S_num_idx` (`S_num`),
  KEY `slect_course_id_idx` (`course_id`),
  CONSTRAINT `slect_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`course_id`),
  CONSTRAINT `slect_S_num` FOREIGN KEY (`S_num`) REFERENCES `student` (`S_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `select_sec`
--

LOCK TABLES `select_sec` WRITE;
/*!40000 ALTER TABLE `select_sec` DISABLE KEYS */;
/*!40000 ALTER TABLE `select_sec` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `S_num` int NOT NULL,
  `ID` varchar(20) DEFAULT NULL,
  `S_name` varchar(45) DEFAULT NULL,
  `S_gender` varchar(10) DEFAULT NULL,
  `S_phone` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`S_num`),
  KEY `ID_idx` (`ID`),
  CONSTRAINT `S_ID` FOREIGN KEY (`ID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (1852829,'00001','赵茜锐','男','19921306160');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplementary_signature`
--

DROP TABLE IF EXISTS `supplementary_signature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplementary_signature` (
  `supply_sign_sheet_id` int NOT NULL,
  `course_id` int DEFAULT NULL,
  `class_date` varchar(15) DEFAULT NULL,
  `s_num` int NOT NULL,
  `supply_sign_reason` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`supply_sign_sheet_id`,`s_num`),
  KEY `supplementary_course_id_idx` (`course_id`),
  KEY `supplementary__s_num_idx` (`s_num`),
  CONSTRAINT `supplementary__s_num` FOREIGN KEY (`s_num`) REFERENCES `student` (`S_num`),
  CONSTRAINT `supplementary_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`course_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplementary_signature`
--

LOCK TABLES `supplementary_signature` WRITE;
/*!40000 ALTER TABLE `supplementary_signature` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplementary_signature` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher` (
  `T_num` int NOT NULL,
  `ID` varchar(20) DEFAULT NULL,
  `T_name` varchar(45) DEFAULT NULL,
  `T_gender` varchar(10) DEFAULT NULL,
  `T_phone` varchar(25) DEFAULT NULL,
  `T_dept` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`T_num`),
  KEY `ID_idx` (`ID`),
  CONSTRAINT `T_ID` FOREIGN KEY (`ID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `time_slot`
--

DROP TABLE IF EXISTS `time_slot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `time_slot` (
  `time_slot_id` int NOT NULL,
  `day` varchar(15) NOT NULL,
  `start_time` varchar(45) DEFAULT NULL,
  `end_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`time_slot_id`,`day`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `time_slot`
--

LOCK TABLES `time_slot` WRITE;
/*!40000 ALTER TABLE `time_slot` DISABLE KEYS */;
/*!40000 ALTER TABLE `time_slot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `ID` varchar(20) NOT NULL,
  `password` varchar(100) DEFAULT NULL,
  `type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('00001','123456','student'),('00002','111111','teacher'),('1212','AQAAAAEAACcQAAAAEHEssUxpzhTyfpII//d9cPJ/DE4XLQKwrL//Fue0rzW2uXI8bl2Zz6KegKwEe9LU4Q==','student');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-09-08 20:33:36
