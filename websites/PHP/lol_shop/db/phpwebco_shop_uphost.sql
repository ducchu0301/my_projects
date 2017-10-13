-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 10, 2014 at 06:37 AM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+09:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `phpwebco_shop`
--
CREATE DATABASE IF NOT EXISTS `b7_20794520_lolgameshop` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `b7_20794520_lolgameshop`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_cart`
--

CREATE TABLE IF NOT EXISTS `tbl_cart` (
  `ct_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pd_id` int(10) unsigned NOT NULL DEFAULT '0',
  `ct_qty` mediumint(8) unsigned NOT NULL DEFAULT '1',
  `ct_session_id` varchar(50) NOT NULL DEFAULT '',
  `ct_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`ct_id`),
  KEY `pd_id` (`pd_id`),
  KEY `ct_session_id` (`ct_session_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_category`
--

CREATE TABLE IF NOT EXISTS `tbl_category` (
  `cat_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cat_parent_id` int(11) NOT NULL DEFAULT '0',
  `cat_name` varchar(50) NOT NULL DEFAULT '',
  `cat_description` varchar(200) NOT NULL DEFAULT '',
  `cat_image` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`cat_id`),
  KEY `cat_parent_id` (`cat_parent_id`),
  KEY `cat_name` (`cat_name`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=39 ;

--
-- Dumping data for table `tbl_category`
--

INSERT INTO `tbl_category` (`cat_id`, `cat_parent_id`, `cat_name`, `cat_description`, `cat_image`) VALUES
(18, 0, 'Champions', 'A champion is a being or person that has been summoned to wage battle on the Fields of Justice.\r\n\r\nPurchase champions to play in-game', 'cb9525694e3e924893ee3fdd005ac26d.jpg'),
(20, 0, 'Runes', 'A rune is an enhancement that the summoner provides for their champion before a match on a field of justice begins to augment the champion''s abilities.\r\n\r\nRunes can only be purchased from the Riot Sto', 'aa4e57ad8fb73bf17b45901c3a3ec31a.png'),
(23, 0, 'Wards', 'A ward is an item that reveals the Fog of War once placed in-game', '8923f50c4485305126f64bd98b71c33a.jpg'),
(24, 20, 'Mark', 'Offensive', '9f6ec94e7111386889d0578727b6b171.png'),
(25, 20, 'Glyph', 'Magical', 'cd1e4a42a526f63c5d3acd09b7e3caf0.png'),
(26, 20, 'Seal', 'Defensive', '1e9693518b547681c53773eca20ec1b7.png'),
(27, 20, 'Quintessence', 'Utility', 'a90126e14e38e3502db8f00788e2e2a8.png'),
(30, 18, 'Aatrox', 'FIGHTER, MELEE', 'db2cc159265059d002a293bb9e18f356.png'),
(31, 18, 'Diana', 'FIGHTER, MAGE, MELEE', '27b6e0f72e9a575e4a82f21af2a4e26d.png'),
(32, 18, 'Ahri', 'ASSASSIN, MAGE, RANGED', 'd3bbd9cf47044399c2240b824642274e.png'),
(33, 23, 'A-L', '...', ''),
(34, 23, 'M-Z', '...', ''),
(35, 18, 'Ezreal', 'CARRY, RANGED', 'b9c6797f3a42063edb92191078621b62.png'),
(37, 18, 'Vel''Koz', 'MAGE, RANGED', '4ec0ad222db23c9f12d7b3fa8abe5264.png'),
(38, 18, 'Annie', 'MAGE, RANGED', '486d128047795a19f8e4a56b6d8aaf9d.png');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_counter`
--

CREATE TABLE IF NOT EXISTS `tbl_counter` (
  `counter` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_counter`
--

INSERT INTO `tbl_counter` (`counter`) VALUES
(2352);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_currency`
--

CREATE TABLE IF NOT EXISTS `tbl_currency` (
  `cy_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cy_code` char(3) NOT NULL DEFAULT '',
  `cy_symbol` varchar(8) NOT NULL DEFAULT '',
  PRIMARY KEY (`cy_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `tbl_currency`
--

INSERT INTO `tbl_currency` (`cy_id`, `cy_code`, `cy_symbol`) VALUES
(1, 'EUR', '&#8364;'),
(2, 'GBP', '&pound;'),
(3, 'JPY', '&yen;'),
(4, 'USD', '$'),
(5, 'RP', 'RP');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_member`
--

CREATE TABLE IF NOT EXISTS `tbl_member` (
  `mem_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `mem_name` varchar(50) NOT NULL,
  `mem_password` varchar(50) NOT NULL,
  `mem_regdate` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `mem_last_login` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `mem_ten` varchar(100) CHARACTER SET utf16le COLLATE utf16le_bin NOT NULL,
  `mem_phai` tinyint(1) NOT NULL,
  `mem_email` varchar(100) NOT NULL,
  `mem_bday` date NOT NULL DEFAULT '0000-00-00',
  PRIMARY KEY (`mem_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- Dumping data for table `tbl_member`
--

INSERT INTO `tbl_member` (`mem_id`, `mem_name`, `mem_password`, `mem_regdate`, `mem_last_login`, `mem_ten`, `mem_phai`, `mem_email`, `mem_bday`) VALUES
(9, 'admin', '21232f297a57a5a743894a0e4a801fc3', '2014-03-23 02:29:14', '2014-04-05 13:23:56', '', 0, '', '0000-00-00'),
(11, 'hankun', '202cb962ac59075b964b07152d234b70', '2014-03-25 00:55:12', '2014-04-10 00:16:20', 'Chu Minh Äá»©c', 0, 'zzhankunzz@gmail.com', '1992-01-03'),
(12, 'cerebi', '250cf8b51c773f3f8dc8b4be867a9a02', '2014-03-25 01:21:45', '0000-00-00 00:00:00', 'Äinh Thá»‹ TÃ²n Ten Táº¡ Thá»‹ Huyá»n TrÃ¢n CÃ´ng Chá»©a', 0, 'tendai@dailam.quadai', '1989-11-09'),
(14, 'dinon', '202cb962ac59075b964b07152d234b70', '2014-03-25 01:23:46', '0000-00-00 00:00:00', 'Hai Ba Bá»‘n', 1, 'one@two.three', '1989-11-09'),
(17, 'taiki', '202cb962ac59075b964b07152d234b70', '2014-03-25 01:49:38', '0000-00-00 00:00:00', 'kudou taiki', 1, 'taiki@gmail.com', '1993-12-02'),
(19, 'dendou', '25f9e794323b453885f5181f1b624d0b', '2014-03-25 23:42:24', '0000-00-00 00:00:00', 'kenshin takao', 1, 'kenshin@gmail.com', '1996-05-12'),
(20, 'duc', '202cb962ac59075b964b07152d234b70', '2014-03-29 21:40:07', '2014-03-29 21:45:02', 'Chu Minh Äá»©c', 1, 'zzhankunzz@gmail.com', '1993-01-03'),
(21, 'minhduc', '202cb962ac59075b964b07152d234b70', '2014-04-09 23:38:09', '2014-04-10 00:11:01', 'Ashahi kimi', 1, 'zzhankunzz@gmail.com', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_new`
--

CREATE TABLE IF NOT EXISTS `tbl_new` (
  `new_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `new_title` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `new_detail` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `new_image` varchar(200) DEFAULT NULL,
  `new_thumbnail` varchar(200) DEFAULT NULL,
  `new_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `new_last_update` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`new_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `tbl_new`
--

INSERT INTO `tbl_new` (`new_id`, `new_title`, `new_detail`, `new_image`, `new_thumbnail`, `new_date`, `new_last_update`) VALUES
(2, 'New free champion rotation: Sivir, Soraka, Teemo and more!', 'Greetings Summoners!\r\n\r\nHere are this week''s free champions, available on Tuesday:\r\n\r\nWeek 11 (this week):\r\nAkali - the Fist of Shadow\r\nJarvan IV - the Exemplar of Demacia\r\nMiss Fortune - the Bounty Hunter\r\nSivir - the Battle Mistress\r\nSona - Maven of the Strings\r\nSoraka - the Starchild\r\nTeemo - the Swift Scout\r\nXerath - the Magus Ascendant\r\nXin Zhao - the Seneschal of Demacia\r\nYasuo - the Unforgiven\r\n\r\nWondering how we picked this week''s free champions? Read up on our forum .\r\nSee you on the Fields of Justice!', '2665770de7c237fe3083b277c8bc1b17.jpg', 'ccac90e5ab36d2746f0b1e5990cba886.jpg', '2014-03-25 18:35:56', '2014-04-10 01:59:27'),
(3, 'Upcoming rune balance changes', 'Back in the 2014 preseason we spoke about rune balance changes but couldn''t deliver them in time for the launch of the season. The short version: we took a closer look at the rune system after our original announcement and decided that our plans weren''t going to get runes where we want them to be. We''re still committed to exploring the best way to make runes an interesting and dynamic system for all players, but in the meantime we''ll be implementing some basic changes in the next patch.\r\n\r\nFor starters, we''re very aware that rune costs are a pain point for many players, so with the upcoming rune balance changes, we''ll be kicking off a 30% off Rune and IP Boost sale that will last from the start of the next patch through the end of April.\r\n\r\nAs for the balance, we''ll be making the following basic changes to runes (we''re only showing the Tier 3 changes, but you can assume roughly equivalent changes for the lower tiers). Supplementary changes in other systems will accompany our only two rune nerfs to armor seals and life steal quintessences. All other rune changes are buffs. It should also be noted that we will not be offering refunds (or meeting the price difference) for runes previously purchased or purchased between this announcement and the official sale start.\r\n\r\nWe''ll be keeping an eye on runes and may need to make additional tweaks for game health reasons, but we''re not currently planning any further significant changes in the 2014 season. We hope you enjoy the upcoming rune sale and take this opportunity to get geared up for the season!', '33229266a9e35138c52cc0c9447c990a.jpg', '18ba88d0011dacf49efcf245e9b6aafe.jpg', '2014-03-25 18:39:40', '2014-04-10 01:59:21'),
(4, 'March bundles out now!', 'Craving something new at champ select? Get fed on these limited time bundles. Theyâ€™re flexible in cost, meaning the final bundle price will automatically adjust to reflect only whatâ€™s new to your collection.\r\n\r\nBig and Tall Bundle â€“ 50% off at 2585 RP (4585 RP if you need the champions)\r\n\r\nItâ€™s an all-you-can-feed-on event in Runeterra, and some of the Fieldâ€™s most ginormous champs have joined forces for some fine dining. Does this skin make me look fed?\r\n\r\nSkins included:\r\n\r\nPool Party Renekton\r\nArcade Hecarim\r\nAstroNautilus\r\nJurassic Choâ€™Gath\r\nGalactic Nasus\r\n\r\nChampions included:\r\n\r\nRenekton\r\nHecarim\r\nNautilus\r\nChoâ€™Gath\r\nNasus', 'a400f63bd982f49770d69100a8306aba.jpg', '7881f52b4bde745a8651433f6b1ea019.jpg', '2014-03-29 22:22:23', '2014-04-10 01:59:15'),
(5, 'Kick off April with a Mystery Skin!', 'Weâ€™re kicking off April with Mystery Skins!\r\n\r\nWhen you purchase a Mystery Skin, youâ€™ll receive a random skin thatâ€™s currently in the store and worth 520 RP or more. As with the first round of Mystery Skins, you can only unlock skins for champions you own.\r\n\r\nMystery Skins will be available in the Skins tab of the store for <b>490 RP</b> and are limited to five per day. Check out Mystery Skins from <b>April 1</b> to <b>April 4</b>!', '750eb0309d679c125a8103741d9c62ea.jpg', 'b37c66fafbe0707ffa3a8f4b5cd9d773.jpg', '2014-03-29 22:24:09', '2014-04-10 01:59:09'),
(6, 'What is League of Legends?', 'League of Legends is a fast-paced, competitive online game that blends the speed and intensity of an RTS with RPG elements. Two teams of powerful champions, each with a unique design and playstyle, battle head-to-head across multiple battlefields and game modes. With an ever-expanding roster of champions, frequent updates and a thriving tournament scene, League of Legends offers endless replayability for players of every skill level.\r\n\r\n<font color="#FF0000"><b>Join the League</b></font>\r\n\r\n<b>Battle Head-to-Head</b>\r\nCombine strategic thinking, lightning reflexes and coordinated team-play to crush your enemies in both small-scale skirmishes and intense 5v5 battles\r\n\r\n<b>Strategize and Evolve</b>\r\nWith regular gameplay updates, multiple maps and game modes, and new champions constantly joining the League, the only limit to your success is your own ingenuity\r\n\r\n<b>Compete Your Way</b>\r\nWhether you''re enjoying a game against bots or climbing the ranks of the league system, League of Legends has the tech to quickly match you with a group of similarly-skilled competitors\r\n\r\n<b>Fight with honor</b>\r\nCompete with honor and receive special commendations from your peers to reward your good sportsmanship\r\n\r\n<b>Experience eSports</b>\r\nAs the world''s most active competitive scene, League of Legends sports numerous tournaments worldwide, including the prestigious Championship Series where salaried pros compete for millions\r\n\r\n<b>World''s Largest Online Gaming Community</b>\r\nJoin the world''s largest online gaming community: make friends, form teams and battle tens of millions of opponents from countries across the globe, then exchange strats on reddit, YouTube, the forums and beyond', '9c2eced43dd95b4e7e34a9528be75c90.jpg', '7f6d55ae02813248217af02d78c816cb.jpg', '2014-04-10 01:45:58', '2014-04-10 01:45:58'),
(7, 'New Player Guide', 'A lot goes into a successful battle on the Field of Justice. Here you''ll learn about the basics of the game, familiarize yourself with the basic mechanics through the in-game tutorials, and take your first steps onto Summoner''s Rift.\r\n\r\n<b>Champions</b>\r\nThe League is filled with champions of every archetype, from devious masterminds to epic monsters and everything in between. Different champions suit different roles and strategies, so don''t get discouraged if the first one you try doesn''t mesh with your playstyle.\r\n\r\n<b>Controlling your champion</b>\r\nWith a few caveats, champions use a traditional RTS control scheme.\r\nTo move your champion, right click on the terrain where you''d like to go\r\nTo attack an enemy, right click on your target\r\nTo cast a spell left-click the associated icon or use the spell''s hotkey (Q,W,E, or R by default), and then click on the target.\r\nControls can be customized through the Options menu.\r\n\r\n<b>Lanes</b>\r\nThere are three roads that connect your base to the enemy''s. These roads are called lanes, and they''ll serve as the means of engaging the enemy team. To win a game you''ll have to push down your lane into the enemy base and destroy the nexus at the heart of their base.\r\n\r\n<b>Minions</b>\r\nMinions are AI-controlled soldiers that spawn at the nexus and march down each lane toward the enemy base, attacking enemies they encounter along the way. Scoring the killing blow on a minion earns valuable gold for your champion. Minions prefer to fight each other, but will attack your champion if they find him alone in lane. They''ll also switch targets to focus on you if you attack a nearby allied champion. Don''t underestimate the power of a big wave of minions, particularly early in the game!\r\n\r\n<b>Turrets</b>\r\nTurrets are powerful defensive structures that defend each lane at even intervals, punishing enemies that come within range with deadly bolts of energy. Like minions, they prefer to attack targets other than you, unless you engage another champion while within range. A hostile turret will only target you if you''re attacking an enemy champion or if you''re the last target in range. Beware of picking a fight under an enemy turret.\r\n\r\n<b>Inhibitors</b>\r\nImportant structures known as inhibitors are located where each lane meets the base on both sides of the map. Destroying an inhibitor creates a powerful super minion each time a new minion wave spawns in that lane. Super minions are extremely durable, making them ideal for leading the charge on the enemy nexus. Inhibitors respawn after five minutes, so be sure to press your advantage during this time.\r\nDestroying all three of an enemy''s inhibitors will cause two super minions to spawn in each lane every time a new minion wave is created.', 'b581b83867144b14399d17d5d3aa318f.jpg', '7ff0d2450dae1262662ead7ef572f04b.jpg', '2014-04-10 01:56:02', '2014-04-10 01:56:02'),
(8, 'Become a Summoner', 'Here you can learn more about the different aspects of your summoner, including the runes, masteries and spells you can use to customize your champion on the Fields of Justice. These powerful tools allow you to tailor a champion to your individual playstyle, opening new strategies and tactics.\r\n\r\nThese powerful abilities allow you to further customize your champion''s kit to suit your playstyle. You can select any two summoner spells at the beginning of a game.\r\n\r\n<b>Offensive Spells</b>\r\nThese spells focus on damaging enemies and chasing down opponents. You can improve them by selecting the Summoner''s Wrath mastery.\r\n\r\n<b>Defensive Spells</b>\r\nThese spells prevent damage and remove negative effects. You can improve them by selecting the Summoner''s Resolve mastery.\r\n\r\n<b>Utility Spells</b>\r\nThese spells provide improved mobility and map presence. You can improve them by selecting the Summoner''s Insight mastery.', '8200efda95812d050a2a68997ac30964.jpg', '86bcec6235e58ad0d28c1e58887e99aa.jpg', '2014-04-10 01:57:46', '2014-04-10 01:57:46');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_order`
--

CREATE TABLE IF NOT EXISTS `tbl_order` (
  `od_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `od_date` datetime DEFAULT NULL,
  `od_last_update` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `od_status` enum('New','Paid','Shipped','Completed','Cancelled') NOT NULL DEFAULT 'New',
  `od_memo` varchar(255) NOT NULL DEFAULT '',
  `od_shipping_first_name` varchar(50) NOT NULL DEFAULT '',
  `od_shipping_last_name` varchar(50) NOT NULL DEFAULT '',
  `od_shipping_address1` varchar(100) NOT NULL DEFAULT '',
  `od_shipping_address2` varchar(100) NOT NULL DEFAULT '',
  `od_shipping_phone` varchar(32) NOT NULL DEFAULT '',
  `od_shipping_city` varchar(100) NOT NULL DEFAULT '',
  `od_shipping_state` varchar(32) NOT NULL DEFAULT '',
  `od_shipping_postal_code` varchar(10) NOT NULL DEFAULT '',
  `od_shipping_cost` decimal(5,2) DEFAULT '0.00',
  `od_payment_first_name` varchar(50) NOT NULL DEFAULT '',
  `od_payment_last_name` varchar(50) NOT NULL DEFAULT '',
  `od_payment_address1` varchar(100) NOT NULL DEFAULT '',
  `od_payment_address2` varchar(100) NOT NULL DEFAULT '',
  `od_payment_phone` varchar(32) NOT NULL DEFAULT '',
  `od_payment_city` varchar(100) NOT NULL DEFAULT '',
  `od_payment_state` varchar(32) NOT NULL DEFAULT '',
  `od_payment_postal_code` varchar(10) NOT NULL DEFAULT '',
  PRIMARY KEY (`od_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `tbl_order`
--

INSERT INTO `tbl_order` (`od_id`, `od_date`, `od_last_update`, `od_status`, `od_memo`, `od_shipping_first_name`, `od_shipping_last_name`, `od_shipping_address1`, `od_shipping_address2`, `od_shipping_phone`, `od_shipping_city`, `od_shipping_state`, `od_shipping_postal_code`, `od_shipping_cost`, `od_payment_first_name`, `od_payment_last_name`, `od_payment_address1`, `od_payment_address2`, `od_payment_phone`, `od_payment_city`, `od_payment_state`, `od_payment_postal_code`) VALUES
(1, '2014-03-19 16:27:00', '2014-03-19 16:41:10', 'Paid', '', '&#7873;dfs', 'Fasdf', 'sdfsad', 'sdfa', 'sdfas', 'Sá', 'sadfs', 'fsaf', '5.00', '&#7873;dfs', 'Fasdf', 'sdfsad', 'sdfa', 'sdfas', 'Sá', 'sadfs', 'fsaf'),
(2, '2014-03-19 16:28:20', '2014-03-19 16:41:28', 'Cancelled', '', 'Duc', 'CHu', 'abcd', 'efgh', '03033333', 'Van', 'trrjen', '7000', '5.00', 'Duc', 'CHu', 'abcd', 'efgh', '03033333', 'Van', 'trrjen', '7000'),
(3, '2014-03-19 16:30:37', '2014-03-19 16:30:37', 'New', '', 'Duc', 'CHu', 'abcd', 'efgh', '03033333', 'Van', 'trrjen', '7000', '5.00', 'Duc', 'CHu', 'abcd', 'efgh', '03033333', 'Van', 'trrjen', '7000');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_order_item`
--

CREATE TABLE IF NOT EXISTS `tbl_order_item` (
  `od_id` int(10) unsigned NOT NULL DEFAULT '0',
  `pd_id` int(10) unsigned NOT NULL DEFAULT '0',
  `od_qty` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`od_id`,`pd_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_order_item`
--

INSERT INTO `tbl_order_item` (`od_id`, `pd_id`, `od_qty`) VALUES
(1, 4, 2),
(2, 4, 3),
(3, 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product`
--

CREATE TABLE IF NOT EXISTS `tbl_product` (
  `pd_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cat_id` int(10) unsigned NOT NULL DEFAULT '0',
  `pd_name` varchar(100) NOT NULL DEFAULT '',
  `pd_description` text NOT NULL,
  `pd_price` float NOT NULL DEFAULT '0',
  `pd_qty` smallint(5) unsigned NOT NULL DEFAULT '0',
  `pd_image` varchar(200) DEFAULT NULL,
  `pd_thumbnail` varchar(200) DEFAULT NULL,
  `pd_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pd_last_update` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`pd_id`),
  KEY `cat_id` (`cat_id`),
  KEY `pd_name` (`pd_name`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=45 ;

--
-- Dumping data for table `tbl_product`
--

INSERT INTO `tbl_product` (`pd_id`, `cat_id`, `pd_name`, `pd_description`, `pd_price`, `pd_qty`, `pd_image`, `pd_thumbnail`, `pd_date`, `pd_last_update`) VALUES
(6, 30, 'Aatrox, the Darkin Blade', 'Aatrox is a legendary warrior, one of only five that remain of an ancient race known as the Darkin. He wields his massive blade with grace and poise, slicing through legions in a style that is hypnotic to behold. With each foe felled, Aatrox''s seemingly living blade drinks in their blood, empowering him and fueling his brutal, elegant campaign of slaughter.', 199.9, 11, 'b3cfd04d0fbc43b851bcad20e50ddb49.jpg', '7bfcbc70736dfd56c2d0605c9df3eeb8.jpg', '2014-03-20 22:23:08', '2014-03-26 00:38:11'),
(7, 31, 'Diana, Scorn of the Moon', 'An unyielding avatar of the moon''s power, Diana wages a dark crusade against the sun-worshiping Solari. Though she once sought the acceptance of her people, years of futile struggle shaped her into a bitter, resentful warrior. She now presents her foes with a terrible ultimatum: revere the moon''s light, or die by her crescent blade.', 199, 5, 'f73a101455c9df401ebed94ac59c9f55.jpg', '6fdc4a8cca77e7b6931b75fab3b4eb70.jpg', '2014-03-20 22:25:53', '0000-00-00 00:00:00'),
(8, 31, 'Lunar Goddess Diana', 'There is a distinct rabbit shaped cloud above the tip of Diana''s Khopesh in the Lunar Goddess skin splash. This could mean the skin is a reference to Chang''e, the Chinese goddess of the moon.\r\n\r\nIn Chinese Server Lunar Goddess skin is named “&#24191;&#23506;&#20185;&#23376; &#23270;&#23077;”&#65288;The fairy of Moon Chang‘e&#65289;, which is officially reference to Chang''e. and base on the skin reveal page by Tencent Games, the skin idea is from an Anonymous Tencent LOL Designer.', 399, 6, 'c5a6893726be245557f517d1a7cabaad.jpg', 'fb3af9b37c3a5180a4543c5f4434c422.jpg', '2014-03-20 22:27:48', '0000-00-00 00:00:00'),
(9, 31, 'Dark Valkyrie Diana', 'Dark Valkyrie Diana is reference to the valkyries, a host of female figures from Norse mythology who wander the battle fields retrieving slain warriors who are to be brought to Valhalla after a glorious death in battle.\r\n\r\nDark Valkyrie Diana skin is the dark counterpart of  Valkyrie Leona skin.\r\n\r\nDark Valkyrie Diana was originally released with a headdress covering the mark on her forehead. The skin was later changed with the removal of the headdress and an alternate face because it bore too much of a resemblance to  Syndra.', 299, 12, '9b77e62e2838dde7fb68e0fc849f6c84.jpg', 'f982f49a9f76eaefff3fdee608780fff.jpg', '2014-03-20 22:33:59', '0000-00-00 00:00:00'),
(10, 30, 'Justicar Aatrox', 'Justicar Aatrox shares the Justicar theme with  Justicar Syndra.\r\n\r\nJusticar Aatrox is meant to resemble Aatrox through the depictions of him by the people whom he saved.', 199, 7, '0604d7b391f2b3808f566ee603ab6f1d.jpg', '0438c00384ec23c6fa22c4e21010add3.jpg', '2014-03-20 22:36:11', '0000-00-00 00:00:00'),
(11, 24, 'Attack Damage', 'Increase your champion''s Attack Damage by 0.95 points', 19, 99, '9f2e58e3956cc022b35cf3cde7a23ac5.png', 'a45c3e9e9ea77439e44da1509e6f6265.png', '2014-03-20 22:45:20', '0000-00-00 00:00:00'),
(12, 24, 'Attack Speed', 'Increase your champion''s Attack Speed by 1.7%', 39, 99, '795f1fa044dc0818ee924cf5e7d55c05.png', '571e21ee053e6501d0ffbbd51d55a4ef.png', '2014-03-20 22:47:05', '0000-00-00 00:00:00'),
(13, 33, 'Haunting Ward', 'A Ward that looks like a ghost.', 79, 99, '76d112629207470786553bfd65ac6832.jpg', 'e378b6230bae69a0228d48d3a52445ea.jpg', '2014-03-20 22:48:57', '0000-00-00 00:00:00'),
(14, 34, 'Snowman Ward', 'A ward that looks like a snowman', 79, 2, 'f5a7a88829ed06368cbb2f7eced82976.jpg', 'bd9781d99c2a0d5b3ae3b3fe3d439766.jpg', '2014-03-20 22:49:52', '0000-00-00 00:00:00'),
(15, 25, 'Ability Power', 'Increase your champion''s Ability Power by 1.19 points', 39, 99, 'd1920c83c180149825ac264d2ac7f2fa.png', 'f0b0df0b1a62c26304f954bf48c45cd7.png', '2014-03-20 22:51:36', '0000-00-00 00:00:00'),
(17, 27, 'Life Steal', 'Increase your champion''s Life Steal by 2%', 205, 99, 'c5f1dc92580f545c7b8a8192ca5a2d65.png', '7a18a57a4f50afed839bec50919eaa9d.png', '2014-03-20 22:54:29', '0000-00-00 00:00:00'),
(18, 32, 'Ahri, the Nine-Tailed Fox', 'Unlike other foxes that roamed the woods of southern Ionia, Ahri had always felt a strange connection to the magical world around her; a connection that was somehow incomplete.\r\n\r\n Deep inside, she felt the skin she had been born into was an ill fit for her and dreamt of one day becoming human. Her goal seemed forever out of reach, until she happened upon the wake of a human battle. It was a grisly scene, the land obscured by the forms of wounded and dying soldiers. \r\n\r\nShe felt drawn to one: a robed man encircled by a waning field of magic whose life was quickly slipping away. She approached him and something deep inside of her triggered, reaching out to the man in a way she couldn''t understand. His life essence poured into her, carried on invisible strands of magic. The sensation was intoxicating and overwhelming. \r\n\r\nAs her reverie faded, she was delighted to discover that she had changed. Her sleek white fur had receded and her body was long and lithe, the shape of the humans who lay scattered about her.', 199, 6, 'b64954a8574689cdc63f5b85cb7fde30.jpg', '074dfe470d9c285cecb5e365c00b7a2b.jpg', '2014-03-23 02:21:26', '2014-03-26 03:53:22'),
(19, 32, 'Dynasty Ahri', 'Dynasty Ahri is wearing modernized Hanbok (traditional Korean clothing).\r\nAdditionally, this skin changes her dance to a traditional Korean dance.', 199, 8, '10581b08be493a2ce812bf77483ed1c1.jpg', '0d0e591673d40f8bedabcc0537238278.jpg', '2014-03-23 02:22:45', '0000-00-00 00:00:00'),
(20, 32, 'Midnight Ahri', 'Ahri''s hairstyle in her main skin is a fish tailed braid. She shares this trait with  Lissandra.', 199, 5, '055edde6dc7deffc7372047dbc7744fc.jpg', 'f05275966785c7d20ed4001f516f1e38.jpg', '2014-03-23 02:27:01', '0000-00-00 00:00:00'),
(21, 32, 'Foxfire Ahri', 'Foxfire Ahri is a reference to the Mozilla Firefox browser as she bears the same color scheme of the browser''s icon in her splash art background.\r\n\r\n Foxfire Ahri shares the internet browser theme with  Explorer Ezreal,  Chrome Rammus, and  Safari Caitlyn.', 299, 3, '0e45a60c1712c52fd9a9cb5d2b8bddcd.jpg', 'e51aa15037add78b9e2ca81ca39b3222.jpg', '2014-03-23 02:27:42', '0000-00-00 00:00:00'),
(22, 32, 'Popstar Ahri', 'Popstar Ahri is a reference to the Korean Pop group, Girls'' Generation. Her outfit, splash art background, dance, and recall animations bear similarity to their 2009 single, "Genie".\r\n\r\nThe skin was announced on November 5th, 2013, which coincided with Girls'' Generation''s release of their single, "My Oh My". A side-by-side comparison can be seen here.\r\n\r\nThis is  Ahri''s first splash art in which her  Orb of Deception is not displayed.', 298, 7, '3b8c1c5e1ed0a72a753c69a5b4f1f029.jpg', '411a045f60776661aa60962b17b7ff9d.jpg', '2014-03-23 02:28:48', '0000-00-00 00:00:00'),
(23, 35, 'Ezreal, the Prodigal Explorer', 'Ezreal was born with the gift of magic flowing through his veins.\r\n\r\nEzreal, however, was also born with a much stronger sense of wanderlust. Put into school to become a skilled techmaturgist, Ezreal quickly became bored with magical studies. By the time the boy genius was eight years old, he had fully mapped out the underground tunnels of Piltover. The quality of his work was so great that the government of Piltover purchased his maps and salaried his services as Piltover''s Grandmaster Explorer. \r\n\r\nThis sealed the deal on Ezreal''s path in life - he would eschew the arcane arts in favor of archaeology. Since then, countless of Ezreal''s adventures have been written about as romanticized stories.', 99, 8, 'eddb67cdd815b17b5152f5981475447b.jpg', '8ed74af7c193619f480f1ca8d0c145f6.jpg', '2014-03-23 02:43:44', '0000-00-00 00:00:00'),
(24, 35, 'Nottingham Ezreal', 'Nottingham Ezreal is a reference to Robin Hood, an archer of legendary skill, famous in English folklore.', 100, 25, '3501732cfb7a9d63ad7356b22d291ae7.jpg', 'f19d3c3a930199472ff96ccab8a3bb33.jpg', '2014-03-23 02:45:02', '0000-00-00 00:00:00'),
(25, 35, 'The Striker Ezreal', 'The Striker Ezreal skin, along with the soccer skins for other champions, appeared just before the 2010 World Cup started, and were removed from the store on October 31st, 2010.', 149, 9, 'b6c96b13554c45bda88c48aad80b5504.jpg', 'ec8e7788a7abdf615517d55c807cb854.jpg', '2014-03-23 02:46:10', '0000-00-00 00:00:00'),
(26, 35, 'Frosted Ezreal', 'Frosted Ezreal was based on a creation of Clockmort named "Nightwalker Ezreal".', 69, 2, 'a25007615bc153f1761fd45e3c031ca2.jpg', '74ecc2e4c49be8adefbc76d660aedb30.jpg', '2014-03-23 02:47:04', '0000-00-00 00:00:00'),
(27, 35, 'Explorer Ezreal', 'Explorer Ezreal could be a reference to the web browser Internet Explorer. He seems to be part of a set of skins that have a browser reference, including  Chrome Rammus,  Safari Caitlyn, and Foxfire Ahri.', 219, 11, 'f3ac5131a673ed1b4ec24966fe0ab2f2.jpg', '351948f56d2462d2f1eee852f12149fb.jpg', '2014-03-23 02:48:28', '0000-00-00 00:00:00'),
(28, 35, 'Pulsefire Ezreal', 'The skin is called "Méga Ezreal" in the French version. It is a reference to the main character from the Megaman/Rockman games. This skin''s release was delayed because, according to Riot, it "wasn''t quite what they wanted". Even before this decision, the skin was used in the MLG. The skin is still in the game files under the name "CyberEzreal" in SIU.\r\n\r\nIts taunt, asking about power levels, is a reference to Dragon Ball Z.\r\n\r\nIt is the first skin to include two personalities in its voice-overs: Ezreal and his suit''s AI, PEARL.[7]\r\n\r\nIt is the first skin to change its appearance depending on the champion''s level. Ezreal''s armor upgrades when he ranked  Trueshot Barrage (minimum levels 6, 11, and 16).\r\n\r\nIt is the first skin priced at RP 3250. It was discounted by 50% for the first four days after release to a price of 1625RP.', 799, 2, '529e1d6407d8add1c719c26e2676b439.jpg', '04bce6ecc7633eb1bff33188d0a7ce3e.jpg', '2014-03-23 02:50:32', '0000-00-00 00:00:00'),
(29, 35, 'TPA Ezreal', 'TPA Ezreal skin is related to "Taipei Assassins", who have won the League of Legends Season 2 World Championship finals.\r\n\r\n TPA Ezreal skin shares a similar hairstyle (including hair color and headset) of Neku Sakuraba, a main character of The World Ends With You game.', 199, 26, '42f29aaad1204fef7d9056d0762f6e5c.jpg', '1e00b44e163807b18e9fee1ad5335d41.jpg', '2014-03-23 02:51:23', '0000-00-00 00:00:00'),
(30, 37, 'Vel''Koz, the Eye of the Void', 'I pass into the sudden glare. Blink. Blink, blink, blink. My eyes adjust and evaluate the landscape before me.\r\n\r\nThere''s a scurrying. I look down to find a small, white creature standing on its hind legs, sniffing at my body. It intrigues me.\r\n\r\nWhat use are you?\r\n\r\nI analyze the creature. A flash of hot magenta light, a dust pile where it was quivering.\r\n\r\nMammalian... nocturnal... impeccable hearing. Incredibly weak. Yet they breed so prodigiously.\r\n\r\n"Hm," I mutter to myself. Hopefully there will be more complex things to be found; those fascinate me.\r\n\r\nConsume and learn: this is my purpose. The others who travel with me are primitive: kill and eat, kill and eat. I need to gather all available information - harvest any valuable resources.\r\n\r\nEventually, we come upon a destroyed city, save for one pristine tower. It appears to be protected - or intentionally left standing. I deconstruct the composition of the ruins. My analysis suggests this habitat was a place of great magic; I''m not surprised it was a target of such destruction. There is something compelling about the tower. While the others are off scavenging, I enter the citadel.\r\n\r\nCryptic instruments are strewn about. I examine one. Another flash of hot magenta light, another dust pile.\r\n\r\nFascinating: a tool to alter their concept of time.\r\n\r\nStrange.\r\n\r\nUnprecedented.\r\n\r\nFrom the state of the tower, it seems the  owner departed only recently. The artifacts left behind have existed in more than one time and place. Some are more complex than others; all are more impressive than anything I have seen on this plane. Clearly, the owner knows things I have not encountered in any of my travels.\r\n\r\nI require such knowledge.\r\n\r\nLeaving the tower, I find the others closing in on the entrance, ready to destroy it as they have destroyed everything else we have met. They will only get in the way of my goal. There are some things the Void should not consume indiscriminately.\r\n\r\nWithout warning, I lash out a tentacle, its tip glowing white hot. Lightning arcs through the first creature, knocking it back. Its screams fade as I extend all three limbs, energy crackling between them, scorching the air where the streams meet. The other two run; they know what''s coming.\r\n\r\nMust they always flee?\r\n\r\nI open my eye wide and unleash a beam of energy, following the escaping creatures. They are instantly reduced to ash. "Hmm. Void-native melting point is inconsistent," I note.\r\n\r\nBut that is of no consequence. The hunger inside me grows. I am ravenous. Insatiable, as never before.\r\n\r\nI have glimpsed the ultimate knowledge.\r\n\r\nAnd I will have it.', 199, 16, '07d78a0d3bdd177ae4a516004338d46f.jpg', 'ae7477b52d0d50c3adff97474ff0042b.jpg', '2014-03-29 23:19:11', '2014-03-29 23:19:11'),
(31, 37, 'Battlecast Vel''Koz', 'Battlecast Vel''Koz features a robotic voice-filter and unique quotes for  Kassadin,  Zilean, Yordles and the Howling Abyss.\r\n\r\nBattlecast Vel''Koz''s appearance bears some resemblance to the Sentinels from the Matrix franchise.\r\n\r\nThis similarity is especially noticeable during Vel''Koz''s enhanced movement animation.\r\n\r\nCreator Viktor and  Battlecast Prime Cho''Gath can be seen in the splash art, as well as an as of now unidentified silhouette that also appears  Creator Viktor''s recall animation.', 399, 4, '9d27a369ca8715bc08133b62cd401a12.jpg', '796511b3575d05d625a95991aea7be2e.jpg', '2014-03-29 23:27:27', '0000-00-00 00:00:00'),
(32, 38, 'Annie Hastur, the Dark Child', 'In the time shortly before the League, there were those within the sinister city-state of Noxus who did not agree with the evils perpetrated by the Noxian High Command. The High Command had just put down a coup attempt from the self-proclaimed Crown Prince Raschallion, and a crack down on any form of dissent against the new government was underway. These political and social outcasts, known as the Grey Order, sought to leave their neighbors in peace as they pursued dark arcane knowledge. The leaders of this outcast society were a married couple: Gregori Hastur, the Grey Warlock, and his wife Amoline, the Shadow Witch. Together they led an exodus of magicians and other intelligentsia from Noxus, resettling their followers beyond the Great Barrier to the northern reaches of the unforgiving Voodoo Lands. Though survival was a challenge at times, the Grey Order''s colony managed to thrive in a land where so many others would have failed.\r\n\r\n<i>"Annie may be one of the most powerful champions ever to have fought in a Field of Justice. I shudder to think of her capabilities when she becomes an adult."</i>\r\nâ€• <b>High Councilor Kiersta Mandrake</b>', 49, 50, '574f9c246603eeb645fcf422b382a385.jpg', 'b2741df481b3a1e908e1d02095266d56.jpg', '2014-03-29 23:31:35', '0000-00-00 00:00:00'),
(33, 38, 'Goth Annie', 'Annie''s Goth skin is one of the four Collector''s Edition skins, along with the complementary skins of  Black Alistar,  Silver Kayle, and  Human Ryze. The skin could be obtained by buying the Digital Copy in the Store, but has since been replaced with Huntress Sivir\r\n\r\nThe skin was to be sold on the 1st of February to the 10th of February as a celebration of a very positive remake and the fact the Collector''s Edition bundle was outdated, this sale was denied and is the first sale of a skin to ever be denied.\r\n\r\nGoth Annie''s rework appears to have been based on the Chinese Artwork.', 299, 0, '3c850f8be0d91bd87ea2fec603495e52.jpg', 'e5f1816bbc1fa71e3b4ac03891d6d2b2.jpg', '2014-03-29 23:33:46', '0000-00-00 00:00:00'),
(34, 38, 'Red Riding Annie', 'Annie''s Red Riding skin is a reference to a famous fairy tale, Little Red Riding Hood.', 99, 7, 'e08231ea35e2a031650750087c045936.jpg', '97e6a3b1a039206e1ce5248eb511208a.jpg', '2014-03-29 23:35:11', '0000-00-00 00:00:00'),
(35, 38, 'Annie In Wonderland', 'Annie''s Wonderland skin is a reference to Alice in Wonderland, with Annie dressed as the titular Alice and Tibbers taking the place of the White Rabbit.\r\n\r\nAnnie in Wonderland was a response to player requests to change Tibbers'' skin. It is classified as a Legendary Skin.\r\n\r\nAs of Annie''s Visual Upgrade in January 2013, all of Annie''s skins feature unique Tibbers'' skin.[7][8]', 399, 1, '85c85cb24a46d1dcc5c5d01cfaa4b3dc.jpg', '36ed3fba132cfb99221482b3fc26b1cc.jpg', '2014-03-29 23:36:49', '0000-00-00 00:00:00'),
(36, 38, 'Prom Queen Annie', 'Annie has four skins which are paired with another champion''s skin:\r\n\r\nProm Queen Annie &  Almost-Prom King Amumu', 199, 9, '9e259b674c8912aa605cc20cf9a709a6.jpg', '0ab0418e0530a08cbf46d8ac5b59ba74.jpg', '2014-03-29 23:38:57', '0000-00-00 00:00:00'),
(37, 38, 'Frostfire Annie', 'Frostfire Annie was originally going to have blonde hair before being changed.[9]', 149, 3, '0756471606b51fb264443973d32f389a.jpg', 'c889541dafabbe534920682f64218ae0.jpg', '2014-03-29 23:40:16', '0000-00-00 00:00:00'),
(38, 38, 'Reverse Annie', 'Reverse Annie, she and her bear will swap costume. Which means, she''s a bear and the bear is her.', 199, 69, 'c1061ff4195677d7282cf2a3a9d59438.jpg', 'f3e34e993dd8cfee7f7a60dcb8e078b6.jpg', '2014-03-29 23:43:24', '0000-00-00 00:00:00'),
(39, 38, 'Franken Tibbers Annie', 'Franken Tibbers Annie is a skin release on halloween 2011 and it''s a limited edition skin.', 199, 1, '1aab17fed282d47cd38f37ad43bafca2.jpg', '3e98886f9a826b4125f08c8255d81530.jpg', '2014-03-29 23:45:20', '0000-00-00 00:00:00'),
(40, 38, 'Panda Annie', 'In Annie''s Panda skin, Tibbers looks alot like the Panda King from the Sly Cooper games, who used flame kun-fu (named flame-fu) & fireworks to fight.\r\n\r\nOddly enough Sly Cooper: Thieves in Time was released in NA on Feb 4th, and it was the newest Sly game in 8 years, and Panda Annie was released on Feb 8th, only 4 days apart from this long awaited game.\r\n\r\nPanda Annie shares a panda themed skin with  Teemo.', 299, 20, '7914d6d1c50c69098b14a717ba58ba10.jpg', 'fa77be26f845c1b5b15b10a13d6e66f5.jpg', '2014-03-29 23:47:07', '0000-00-00 00:00:00'),
(41, 34, 'Starcall Ward', 'Champion based design: Soraka', 29, 30, '726d61c253653eb9019524fd0e6a5a6c.jpg', '9212ec11e0bccef15d5427292dbb153c.jpg', '2014-03-29 23:50:39', '0000-00-00 00:00:00'),
(42, 34, 'Ward of Draven', 'It belongs to Draven, absolutely!!!', 39, 35, '8dca66dd1cc6b1f03bf22af9aaa168e1.jpg', '6a49ff6f1ef37cb5076628874dcb9731.jpg', '2014-03-29 23:51:43', '0000-00-00 00:00:00'),
(43, 33, 'Luminosity Ward', 'Lux''s staff and now it''s a ward', 39, 11, '7fb03d640ca8ed676b8e4891aa6f92bf.jpg', '614967be9e8c39296f315be8aa7a70a8.jpg', '2014-03-29 23:52:50', '0000-00-00 00:00:00'),
(44, 34, 'Season 3 Championship Ward', 'Release when the season 3 championship''s about to end. A ward which design so modern, style and has III symbol', 69, 33, 'afd76f3139d9b0e16cc7ad9ed7e8d3cc.jpg', 'e93b550d86be18d63c3c4cd3d20df43e.jpg', '2014-03-29 23:55:09', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_shop_config`
--

CREATE TABLE IF NOT EXISTS `tbl_shop_config` (
  `sc_name` varchar(50) NOT NULL DEFAULT '',
  `sc_address` varchar(100) NOT NULL DEFAULT '',
  `sc_phone` varchar(30) NOT NULL DEFAULT '',
  `sc_email` varchar(30) NOT NULL DEFAULT '',
  `sc_shipping_cost` decimal(5,2) NOT NULL DEFAULT '0.00',
  `sc_currency` int(10) unsigned NOT NULL DEFAULT '1',
  `sc_order_email` enum('y','n') NOT NULL DEFAULT 'n'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_shop_config`
--

INSERT INTO `tbl_shop_config` (`sc_name`, `sc_address`, `sc_phone`, `sc_email`, `sc_shipping_cost`, `sc_currency`, `sc_order_email`) VALUES
('League Of Legend online shop', 'Someplace in the Earth', '+84 555 555 555 - Luke', 'lol_online_shop@riot.com', '1.00', 4, 'y');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE IF NOT EXISTS `tbl_user` (
  `user_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_name` varchar(20) NOT NULL DEFAULT '',
  `user_password` varchar(32) NOT NULL DEFAULT '',
  `user_regdate` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `user_last_login` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`user_id`, `user_name`, `user_password`, `user_regdate`, `user_last_login`) VALUES
(1, 'admin', '43e9a4ab75570f5b', '2005-02-20 17:35:44', '2014-04-10 01:41:22'),
(3, 'webmaster', '026cf3fc6e903caf', '2005-03-02 17:52:51', '0000-00-00 00:00:00');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
