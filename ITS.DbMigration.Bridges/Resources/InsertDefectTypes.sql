﻿INSERT INTO bridges_defect_type(id, name, pattern, section_id) VALUES     
--1 ДЕФЕКТЫ МАТЕРИАЛОВ
--1.1 Дефекты бетона в железобетонных конструкциях
--1.1.1 Дефекты поверхности
(1, 'Протечки', 'F или L:float', 1),
(2, 'Выщелачивание', 'F или L:float', 1),
(3, 'Шелушение поверхностное (до 5 мм глубиной)', 'F или L:float', 1),
(4, 'Раковины и сколы незначительной глубины (до 10мм)', 'F или L:float', 1),
(5, 'Раковины и сколы глубиной более 10мм', 'F или L:float', 1),
--1.1.2 Разрушение защитного слоя
(6, 'Без оголения арматуры', 'F или L:float', 2),
(7, 'С оголением распределительной арматуры или хомутов', 'F или L:float', 2),
(8, 'С оголением основной арматуры (каркаса, пучков)', 'F или L:float', 2),
(9, 'Недостаточная толщина защитного слоя', 'F или L:float', 2),
--1.1.3 Трещины
(10, 'Трещины не силового характера', 'F или l,C:float', 3),
(11, 'Поперечные силовые трещины в растянутой зоне изгибаемых элементов', 'l:float;C:float', 3),
(12, 'Наклонные (косые) трещины в зоне действия поперечных сил', 'l:float;C:float', 3),
(13, 'Продольные трещины в сжатой зоне', 'l:float;C:float', 3),
(14, 'Трещины коррозии вдоль основной арматуры', 'l:float;C:float', 3),
--1.1.4 Разрушение бетона
(15, 'Одиночные места с разрушением бетона на различную толщину элемента', 'F:float;T:float', 4),
(16, 'Проломы плит, ребер, швов омоноличивания, стенок', 'F:float', 4),
(17, 'Размораживание бетона', 'F:float', 4),
--1.1.5 Повреждение стыков в сборных конструкциях
(18, 'Протечки по стыкам', 'L:float;n:int', 5),
(19, 'Выщелачивание по стыкам', 'L:float;n:int', 5),
(20, 'Трещины в заполнении и по кромкам', 'L:float;n:int', 5),
(21, 'Частичный или полный вынос заполнения;(выкрашивание раствора)', 'L:float;n:int', 5),
(22, 'Разрушение кромок бетона у стыков', 'L:float;n:int', 5),
(23, 'Коррозия стальных накладок и закладных деталей', 'L:float;n:int', 5),
(24, 'Разрушение стальных накладок', 'n:int', 5),
--1.2 Дефекты арматуры
--1.2.1 Коррозия стержневой арматуры
(25, 'Поверхностная (слабый налет)', 'F:float', 6),
(26, 'Язвенная (точечная коррозия)', 'F:float', 6),
(27, 'Ослабление сечения', 'L:float;T:float;A:float;', 6),
(28, 'Образование толстых окислов', 'L:float;T:float;A:float;', 6),
(29, 'Разрывы арматурных элементов (ослабление сечения на 60% и более)', 'L:float;T:float;A:float;n:int', 6),
--1.3 Дефекты металла сатльных конструкций
--1.3.1 Повреждение защитного (окрасочного) слоя
(30, 'Точечное повреждение краски', 'F:float', 7),
(31, 'Трещины (сетка трещин)', 'F:float', 7),
(32, 'Отслоение верхнего слоя без повреждения нижнего', 'F:float', 7),
(33, 'Локальное повреждение со следами ржавчины', 'F:float', 7),
(34, 'Разрушение покрытия до металла (отсутствие покрытия)', 'F:float', 7),
--1.3.2 Коррозия металла
(35, 'Тонкий равномерный слой поверхностной ржавчины', '', 8),
(36, 'Местная или локальная (пятнами), незначительная глубина проникновения (до 0,25мм)', 'F:float', 8),
(37, 'Язвенная коррозия', 'F:float', 8),
(38, 'Сплошная коррозия на значительную глубину', 'F:float;T:float', 8),
--1.3.3. Искривление элементов
(39, 'Выпучивание элементов (поясов, стенок, прокатных профилей)', 'n:int;L:float;F:float', 9),
(40, 'Непрямолинейное положение элементов в плане', 'n:int;W:float', 9),
(41, 'Скручивание элементов', 'n:int', 9),
--1.3.4. Повреждения стыков
(42, 'Неплотное обжатие элементов (наличие щелей)', 'n:int', 10),
(43, 'Повреждение болтов или заклепок', 'n:int', 10),
(44, 'Болты и заклепки установлены не в полном объеме', 'n:int', 10),
(45, 'Щелевая коррозия', 'n:int', 10),
(46, 'Раковины в сварных швах', 'n:int', 10),
--1.3.5. Разрушение (повреждение)элементов
(47, 'Трещины в местах приварки элементов (трещин в зоне швов и в сварных швах)', 'n:int;L:float', 11),
(48, 'Трещины в основном металле (пояса, стенки, стыки)', 'L:float', 11),
(49, 'Разрывы сечения от силовых воздействий', 'n:int', 11),
--1.4.1. Развитие загнивания
(50, 'Начальная стадия (поверхностный грибок)', 'N:int', 12),
(51, 'Загнивание с ослаблением сечения', 'N:int;A:float', 12),
(52, 'Разрушение (выключение из работы) элемента из-за загнивания', 'n:int', 12),
--1.4.2. Трещины
(53, 'Поверхностные (не глубокие) трещины', 'L:float;N:int', 13),
(54, 'Расслоение продольными трещинами', 'L:float;N:int', 13),
--1.4.3. Разрушение (повреждение) в узлах
(55, 'Скол древесины', 'n:int', 14),
(56, 'Смятие древесины', 'n:int', 14),
(57, 'Разрушение сечений (перелом)', 'n:int', 14),
--2 ДЕФЕКТЫ ЭЛЕМЕНТОВ МОСТОВОГО ПОЛОТНА
--2.1. Покрытие
--2.1.1. Трещины
(58, 'Одиночные продольные, поперечные', 'n:int;C:float', 15),
(59, 'Частые продольные, поперечные', 'n:int;C:float', 15),
(60, 'Частые с разрушением кромок', 'F:float', 15),
(61, 'Сетка трещин', 'F:float;C:float', 15),
--2.1.2. Неровности (волны, наплывы, келейность)
(62, 'Одиночные продольные или поперечные', 'L:float;T:float', 16),
(63, 'Регулярные, частые.', 'F:float;h:float;T:float', 16),
--2.1.3. Разрушения
(64, 'Одиночные выбоины в пределах верхнего слоя покрытия', 'n:int;A:float', 17),
(65, 'Частые выбоины в пределах верхнего слоя покрытия', 'F:float', 17),
(66, 'Одиночные выбоины на всю толщину', 'n:int', 17),
(67, 'Частые выбоины на всю толщину покрытия', 'F:float', 17),
(68, 'Разрушение покрытия и нижележащих cлоев одежды (защитного слоя и др.)', 'F:float', 17),
--2.1.4. Повреждение поверхности бетона
(69, 'Шелушение', 'L(F):float;A:float', 18),
(70, 'Одиночные сколы и раковины без оголения арматуры', 'L(F):float;A:float', 18),
(71, 'Частые сколы и раковины без оголения арматуры', 'L(F):float;A:float', 18),
(72, 'Частые сколы и раковины с оголением арматуры', 'L(F):float;A:float', 18),
--2.1.5 Трещины - см. п.2.1.1.
(73, 'Одиночные продольные, поперечные', 'n:int;C:float', 19),
(74, 'Частые продольные, поперечные', 'n:int;C:float', 19),
(75, 'Частые с разрушением кромок', 'F:float', 19),
(76, 'Сетка трещин', 'F:float;C:float', 19),
--2.1.6 Швы в плитах
(77, 'Трещины по заполнению в швах ', 'L:float', 20),
(78, 'Разрушение материала заполнения', 'L:float', 20),
(79, 'Трещины по кромкам швов', 'L:float', 20),
(80, 'Разрушения кромок швов', 'L:float', 20),
--2.1.7 Разрушение плит
(81, 'Расчленение плит на блоки (куски) трещинами', 'F:float', 21),
(82, 'Разрушение плит с выносом кусков', 'F:float', 21),
--2.2 Гидроизоляция
--2.2.1 Одиночные точечные протечки в плитах снизу
(83, 'Одиночные точечные протечки в плитах снизу', 'L:float;F:float', 22),
--2.2.2 Локальные протечки
(84, 'Локальные протечки', 'F:float', 23),
--2.2.3 Протечки по плитам
(85, ' Протечки по плитам', 'F:float', 24),
--2.3 Система водоотвода
--2.3.1 Застой воды на ездовом полотне
(86, 'Одиночный (до 1м2)', 'F:float', 25),
(87, 'Во многих местах ', 'F:float', 25),
(88, 'Локальный (вследствие отсутствия уклоновк трубкам или окнам)', 'F:float', 25),
(89, 'Сплошной', 'F:float', 25),
--2.3.2 Застой воды на тротуаре
(90, 'Одиночный', 'F:float', 26),
(91, 'Локальный', 'F:float', 26),
(92, 'Сплошной', 'F:float', 26),
--2.3.3 Отсутствие уклонов
(93, 'Продольный общий', 'L:float', 27),
(94, 'Поперечный общий', 'L:float', 27),
(95, 'Продольный и поперечный', 'L:float', 27),
(96, 'Продольный на участке между трубками', 'L:float', 27),
--2.3.4 Дефекты водоотводных трубок
(97, 'Повреждены (имеются сколы)', 'n:int;N:int', 28),
(98, 'Трубки загрязнены', 'n:int;N:int', 28),
(99, 'Короткие трубки', 'n:int;N:int', 28),
(100, 'Трубки отсутствуют (имеются отверстия)', 'n:int;N:int', 28),
(101, 'Трубки и отверстия отсутствуют', 'n:int;N:int', 28),
--2.3.5 Дефекты организованного продольного отвода
(102, 'Недостаточный уклон', 'L:float', 29),
(103, 'Загрязнение', 'L:float', 29),
(104, 'Повреждение лотков', 'L:float', 29),
(105, 'Нарушен сброс в коллекторную систему или на землю', 'n:int', 29),
--2.3.6 Нарушен водосброс на подходах
(106, 'Вода не поступает в лотки (нарушены уклоны)', 'L:float', 30),
(107, 'Вода идет мимо лотков, из-за чего имеются промоины в конусах (откосах)', 'N:int', 30),
(108, 'Вымывание воды из-под переходных плит', '', 30),
--2.3.7 Дренаж
(109, 'Одиночные протечки вдоль дренажа между дренажными трубками', 'n:int', 31),
(110, 'Дренажные трубки не функционируют', 'L:float', 31),
(111, 'Дренаж отсутствует', 'S:float', 31),
--2.4 Сопряжение с насыпью
--2.4.1 Нарушение профиля
(112, 'Отсутствует продольный уклон', 'Bl:bool;A:float', 32),
(113, 'Отсутствуют поперечные уклоны', 'Bl:bool;A:float', 32),
(114, 'Отсутствуют продольные и поперечные уклоны', 'Bl:bool;A:float', 32),
(115, 'Наличие угла перелома', 'Bl:bool;A:float', 32),
--2.4.2 Просадки над переходными плитами разной глубины
(116, 'Просадки над переходными плитами разной глубины', 'Y:float', 33),
--2.4.3 Дефекты покрытия
(117, 'Дефекты покрытия', 'Y:float', 34),
--2.4.4 Дефекты переходных плит
(118, 'Смещение в поперечном направлении', 'X:float', 35),
(119, 'Сползание плит с мест опирания (без обрушения)', 'n:float', 35),
(120, 'Обрушения плит', 'n:float', 35),
(121, 'Обрушение плит с обрушением свода одежды', 'n:float', 35),
--2.5 Тротуары
--2.5.1 Повреждение тротуарных блоков и тротуарных плит
(122, 'Шелушение', 'F:float;L:float', 36),
(123, 'Незначительные по глубине раковины и сколы на поверхности', 'F:float;L:float', 36),
(124, 'Раковины и сколы глубиной более 10см', 'F:float;L:float', 36),
(125, 'Разрушение защитного слоя', 'F:float;L:float', 36),
(126, 'Трещины', 'F:float;L:float', 36),
--2.5.2 Разрушение покрытия на тротуаре
(127, 'Разрушение покрытия на тротуаре', 'F:float;L:float', 37),
--2.5.3 Сужение прохода для пешеходов
(128, 'Загрязнения (по ширине загрязнения)', 'Bl:float;L:float', 38),
(129, 'Из-за проломов плит (В - ширина проломов)', 'Bl:float;L:float', 38),
(130, 'Из-за наличия посторонних предметов', 'Bl:float;L:float', 38),
--2.5.4 Загрязнение.
(131, 'Загрязнение', 'h:float;L:float', 39),
--2.5.5 Разрушение тротуарных блоков и плит
(132, 'Смещение', 'n:int;X:float', 40),
(133, 'Проломы в плите', 'n:int;F:float', 40),
(134, 'Выпадение блоков', 'n:int', 40),
--2.6 Перила
--2.6.1 Повреждение окраски или штукатурки
(135, 'Шелушение', 'L:float', 41),
(136, 'Растрескивание', 'L:float', 41),
(137, 'Отслоение', 'L:float', 41),
--2.6.2 Коррозия перил
(138, 'Поверхностная', 'L:float;A:float', 42),
(139, 'Язвенная', 'L:float;A:float', 42),
(140, 'Пластовая, уменьшающая сечение', 'L:float;A:float', 42),
--2.6.3 Механические повреждения
(141, 'Местные погнутости деталей', 'n:int;L:float', 43),
(142, 'Разрывы (разрушения)', 'n:int;L:float', 43),
(143, 'Обрушение секций (деталей)', 'n:int;L:float', 43),
--2.6.4 Нарушение прямолинейности и устойчивости
(144, 'Прогиб поручня', 'L:float;Y:float;Bl:bool', 44),
(145, 'Перила шатаются от руки или при движении автомобилей', 'L:float;Y:float;Bl:bool', 44),
--2.7 Деформационные швы
--2.7.1 Нарушение герметичности
(146, 'Одиночные (точечные) протечки', 'B:float;Bl:bool', 45),
(147, 'Протечки через поврежденное заполнение', 'B:float;Bl:bool', 45),
(148, 'Протечки из под гидроизоляции под сопряжением шва с одеждой', 'B:float;Bl:bool', 45),
(149, 'Разрушение водоотводных лотков', 'B:float;Bl:bool', 45),
(150, 'Попадание грязи через шов на опорные площадки', 'B:float;Bl:bool', 45),
--2.7.2 Нарушение плавности проезда, снижение надежности
(151, 'Трещины в покрытие у шва и над швом', 'C:float;B:float', 46),
(152, 'Образование бугров в покрытие у шва и над швом', 'C:float;B:float', 46),
(153, 'Разрушения покрытия в зоне шва', 'B:float', 46),
(154, 'Разрушения заполнения, отрыв листов повреждения узлов', 'B:float', 46),
(155, 'Разрушения слоев одежды у шва', 'B:float', 46),
(156, 'Расшатывание окаймления', 'B:float', 46),
(157, 'Разрушение, отрыв и проваливание в зазор конструкций', 'B:float', 46),
--2.7.3 Неправильное применение
(158, 'Применен ошибочный тип шва', 'n:int', 47),
(159, 'Не выдержан зазор', 'n:int', 47),
--2.8 Ограждения
--2.8.1 Повреждение конструкций
(160, 'Повреждения окраски', 'L:float', 48),
(161, 'Шелушение бетонной поверхности', 'L:float', 48),
(162, 'Трещины в бордюрах и бетонных парапетах', 'L:float', 48),
(163, 'Разрушение бордюров, сколы в парапетах', 'L:float', 48),
(164, 'Погнутости элементов', 'L:float', 48),
(165, 'Отсутствие амортизаторов', 'L:float', 48),
(166, 'Обрушение балок, стоек или их существенная деформация', 'L:float', 48),
--2.8.2 Недостатки установки (применения)
(167, 'Недостаточная высота', 'L:float;dh:float;dE:float', 49),
(168, 'Недостаточная энергоемкость', 'L:float;dh:float;dE:float', 49),
--2.9 Дорожные знаки
--2.9.1 Отсутствие разметки
(169, 'Отсутствие разметки', 'L:float', 50),
--2.9.2 Нарушение правил установки знаков
(170, 'Нарушение правил установки знаков', 'n:int', 51),
--2.9.3 Знак неразборчив или сломан 
(171, 'Знак неразборчив или сломан', 'n:int', 52),
--2.9.4 Отсутствие необходимого знака
(172, 'Отсутствие необходимого знака', 'n:int', 53),
--2.9.5 Отсутствие навигационных знаков, габаритных огней
(173, 'Отсутствие навигационных знаков, габаритных огней', 'n:int', 54),
--3 Дефекты Ж/Б элементов пролетного строения
--3.1 Крайние балки
--3.2 Средние балки
--3.1.1 (3.2.1) Дефекты поверхности балки
(174, 'Протечки', 'F:float;L:float', 55),
(175, 'Выщелачивание', 'F:float;L:float', 55),
(176, 'Шелушение', 'F:float;L:float', 55),
(177, 'Поверхностные раковины (сколы на глубину до 10 мм)', 'F:float;L:float', 55),
(178, 'Глубокие раковины и сколы', 'F:float;L:float', 55),
(179, 'Загрязнение фасадных поверхностей и опорных узлов', 'F:float;L:float', 55),
--3.1.2 (3.2.2) Дефекты защитного слоя балки
(181, 'Дефекты защитного слоя балки', 'F:float', 56),
--3.1.3 (3.2.3) Трещины балки
(182, 'Трещины балки', 'F:float', 57),
--3.1.4 (3.2.4) Разрушение бетона балки
(183, 'Разрушение бетона балки', 'F:float;L:float;T:float', 58),
--3.1.5 (3.2.5) Повреждение поперечных швов составленных по длине балок
(184, 'Повреждение поперечных швов составленных по длине балок', 'X:float;Y:float;Z:float;C:float;L:float', 59),
(185, 'Смещение блоков балок', 'X:float;Y:float;Z:float;C:float;L:float', 59),
(186, 'Непроклей клеевого соединения', 'X:float;Y:float;Z:float;C:float;L:float', 59),
(187, 'Трещины по шву', 'X:float;Y:float;Z:float;C:float;L:float', 59),
(188, 'Трещины в блоке (в защитном слое) у шва', 'X:float;Y:float;Z:float;C:float;L:float', 59),
--3.1.6 (3.2.6) Дефекты рабочей арматуры (см. п. 1.2.1)
(189, 'Дефекты рабочей арматуры', 'n:int;N:int', 60),
(190, 'Коррозия торцевых обойм, оголение бетона у обойм;', 'n:int;N:int', 60),
(191, 'Коррозия анкеров (в т. ч. внутри бетона)', 'n:int;N:int', 60),
--3.3 Связи поперечные (поперечные балки, диафрагмы, продольные швы омоноличивания)
--3.3.1 Дефекты поверхности  поперечной связи
(192, 'Дефекты поверхности  поперечной связи', 'n:int', 61),
--3.3.2 Разрушения защитного слоя  поперечной связи.
(193, 'Разрушения защитного слоя  поперечной связи', 'n:int', 62),
--3.3.3 Трещины  поперечной связи (п.п. 1+5 разд. 1.1.3.) ПОМОЙКА
(194, 'Трещины  поперечной связи', 'L:float', 63),
(195, 'Трещины по контакту плиты с продольными швами омоноличивания', 'L:float', 63),
(196, 'То же со следами выщелачивания, коррозии', 'L:float', 63),
--3.3.4 Разрушение бетона поперечной связи.
(197, 'Разрушение бетона поперечной связи', '', 64),
--3.3.5 Повреждение стыков  поперечной связи.
(198, 'Повреждение стыков  поперечной связи', '', 65),
--3.3.6 Дефекты рабочей арматуры  поперечной связи.
(199, 'Дефекты рабочей арматуры  поперечной связи', '', 66),
--3.4 Плиты
--3.4.1 Дефекты поверхности плит (п.п. Н5)
(200, 'Дефекты поверхности плит', 'F:float;L:float', 67),
(201, 'Загрязнение консолей в приопорных и средних участков', 'F:float;L:float', 67),
--3.4.2 Разрушения защитного слоя плит
(202, 'Разрушения защитного слоя плит', 'F:float;L:float', 68),
--3.4.3 Трещины плит
(203, 'Трещины плит', 'F:float;L:float', 69),
--3.4.4 Разрушение бетона плит
(204, 'Разрушение бетона плит', 'F:float;L:float', 70),
--3.4.5 Повреждение стыков плит (п.п.1-7 разд. 3.1.5.).
(205, 'Повреждение стыков плит', 'F:float;L:float', 71),
(206, 'Непроклей соединений', 'F:float;L:float', 71),
--3.4.6 Повреждение арматуры плит (п.п, 1 ^5 разд. 1.2.1.).
(207, 'Повреждение арматуры плит', 'F:float;L:float', 72),
(208, 'Смещение сетки плиты (каркаса) к нижней поверхности плиты', 'F:float;L:float', 72),
--3.5 Крайние плиты
--3.6 Средние плиты
--3.5.1 Дефекты поверхности. 
(209, 'Дефекты поверхности.', 'F:float', 73),
--3.5.2 Разрушения защитного слоя.
(210, 'Разрушения защитного слоя', 'F:float;T:float', 74),
--3.5.3 Трещины (п. п. 1, 2, 5 разд.1.1.3.)
(211, 'Трещины', 'n:int;T:float', 75),
--3.5.4 Разрушение бетона
(212, 'Одиночные места с глубокими выколами бетона;', 'n:int;T:float', 76),
(213, 'Проломы плит в пустотных конструкциях', 'n:int;T:float', 76),
--3.5.5 Повреждение стыков **.
(214, 'Повреждение стыков', 'n:int;L:float', 77),
--3.5.6 Дефекты рабочей арматуры 
(215, 'Дефекты рабочей арматуры', '', 78),
--4 Дефекты элементов сталежелезобетонных пролетных строений
--4.1 Железобетонная плита (см. разделы 1.1 и 1.2.)
--4.1.1 Дефекты поверхности плиты
(216, 'Дефекты поверхности железобетонной плиты', 'L:float;F:float', 79),
--4.1.2 Разрушения защитного слоя плиты
(217, 'Разрушения защитного слоя железобетонной плиты', 'L:float;F:float', 80),
--4.1.3 Трещины плиты
(218, 'Трещины железобетонной плиты', 'C:float;l:float;F:float', 81),
--4.1.4 Разрушение бетона плиты.
(219, 'Разрушение бетона плиты', 'L:float;F:float', 82),
--4.1.5 Повреждение стыков при использовании сборных плит.
(220, 'Повреждение стыков при использовании сборных плит', 'L:float;n:int', 83),
--4.1.6 Повреждение арматуры.
(221, 'Повреждение арматуры железобетонной плиты', 'F:float', 84),
--4.1.7 Дефекты узла объединения плиты с балкой
(222, 'Трещина по контакту плиты с балкой', 'n:int;l:float', 85),
(223, 'Наличие просветов между плитой и балкой', '6:float;n:int;l:float', 85),
(224, 'Трещины в месте расположения жестких упоров', '', 85),
--4.2.1 Повреждение окрасочного слоя
(225, 'Повреждение окрасочного слоя крайней балки', 'F:float', 86),
--4.2.2 Коррозия металла
(226, 'Коррозия металла крайней балки', 'F:float', 87),
--4.2.3 Искривление элементов
(227, 'Искривление элементов крайней балки', 'Z:float;N:int', 88),
--4.2.4 Повреждение стыков
(228, 'Повреждение стыков крайней балки', 'n:int;N:int', 89),
--4.2.5 Разрушение (повреждение) элементов
(229, 'Разрушение (повреждение) элементов крайней балки', 'n:int;N:int', 90),
--4.4 Связи
--4.4.1 
--4.4.2
--4.4.3 
--4.4.4 
--4.4.5 
(230, 'Повреждение окрасочного слоя связей', 'F:float', 91),
(231, 'Коррозия металла связей', 'F:float', 92),
(232, 'Искривление элементов связей', 'Z:float;N:int', 93),
(233, 'Повреждение стыков связей', 'n:int;N:int', 94),
(234, 'Разрушение (повреждение) элементов связей', 'n:int;N:int', 95),
--ПОМОЙКА
--4.5 Балки
--4.6 Прогон
--4.5.1 Повреждение окрасочного слоя
(235, 'Повреждение окрасочного слоя балки', 'F:float', 96),
--4.5.2 Коррозия металла
(236, 'Коррозия металла балки', 'F:float', 97),
--4.5.3 Искривление элементов. 
(237, 'Искривление элементов балки', 'n:int;Z:float', 98),
--4.5.4 Повреждение стыков
(238, 'Повреждение стыков балки', 'n:int', 99),
--4.5.5 Разрушение элементов.
(239, 'Разрушение элементов балки', 'n:int', 100),
--4.5.6 Загрязнение нижних поясов
(240, 'Попадание грязи через водоотводные трубки', 'n:int', 101),
(241, 'Попадание грязи через деформационные швы', 'L:float;F:float', 101),
(242, 'Прочие загрязнения', '', 101),
--4.7 Связи
--4.7.1
(243, 'Повреждение окрасочного слоя связей балки', 'F:float', 102),
--4.7.2.
(244, 'Коррозия металла связей балки', 'F:float', 103),
--4.7.3
(245, 'Искривление элементов связей балки', 'n:int;Z:float', 104),
--4.7.4
(246, 'Повреждение стыков связей балки', 'n:int', 105),
--4.7.5 
(247, 'Разрушение элементов связей балки', 'n:int', 106),
--4.7.6
(248, 'Попадание грязи через водоотводные трубки связей балки', 'n:int', 107),
--4.7.7
(249, 'Попадание грязи через деформационные швы связей балки', 'L:float;F:float', 108),
--4.7.8
(250, 'Прочие загрязнения связей балки', '', 109),
--ПОМОЙКА
--5 Дефекты элементов стальных пролетных строений
--5.1 Балочная клетка
--5.1.1 Повреждение настила
(251, 'Повреждение окрасочного слоя настила', 'F:float', 110),
(252, 'Коррозия листа снизу', 'F:float', 110),
(253, 'Повреждение сварных швов', 'n:int', 110),
(254, 'Протечки воды (ржавые потеки)', 'n:int', 110),
--5.1.2 Повреждение ребер ортотропных плит
(255, 'Повреждение окрасочного слоя ортотропных плит', 'F:float', 111),
(256, 'Коррозия металла ортотропных плит', 'F:float', 111),
(257, 'Искривление элементов ортотропных плит', 'n:int;Z:float', 111),
(258, 'Повреждение сварных швов ортотропных плит', 'n:int;L:float', 111),
--5.1.3 Повреждение поперечных балок
(259, 'Повреждение окрасочного слоя поперечных балок', 'F:float', 112),
(260, 'Коррозия металла поперечных балок', 'F:float', 112),
(261, 'Искривление элементов поперечных балок', 'n:int;Z:float', 112),
(262, 'Повреждение стыков поперечных балок', 'n:int', 112),
(263, 'Разрушение элементов поперечных балок', 'n:int', 112),
--5.1.4 Повреждение подтротуарной продольной фасадной посадной балки
(264, 'Повреждение окрасочного слоя продольной фасадной посадной балки', 'F:float', 113),
(265, 'Коррозия металла продольной фасадной посадной балки', 'F:float', 113),
(266, 'Искривление элементов продольной фасадной посадной балки', 'n:int;Z:float', 113),
(267, 'Повреждение стыков продольной фасадной посадной балки', 'n:int', 113),
(268, 'Разрушение элементов продольной фасадной посадной балки', 'n:int', 113),
--5.2 Балки (в соответствии с разделами 4.2.-4.4)
--5.4 Раскосы
--5.4.1 Повреждение окрасочного слоя раскосов
(269, 'Повреждение окрасочного слоя крайней балки раскосов', 'F:float', 114),
--5.4.2 Коррозия металла раскосов
(270, 'Коррозия металла крайней балки раскосов', 'F:float', 115),
--5.4.3 Искривление элементов раскосов
(271, 'Искривление элементов крайней балки раскосов', 'Z:float;N:int', 116),
--5.4.4 Повреждение стыков раскосов
(272, 'Повреждение стыков крайней балки раскосов', 'n:int;N:int', 117),
--5.4.5 Разрушение (повреждение) элементов раскосов
(273, 'Разрушение (повреждение) элементов крайней балки раскосов', 'n:int;N:int', 118),
--5.5 Связи
--5.5.1 Повреждение окрасочного слоя связей ферм и арок
(274, 'Повреждение окрасочного слоя крайней балки связей ферм и арок', 'F:float', 119),
--5.5.2 Коррозия металла связей ферм и арок
(275, 'Коррозия металла крайней балки связей ферм и арок', 'F:float', 120),
--5.5.3 Искривление элементов связей ферм и арок
(276, 'Искривление элементов крайней балки связей ферм и арок', 'Z:float;N:int', 121),
--5.5.4 Повреждение стыков связей ферм и арок
(277, 'Повреждение стыков крайней балки связей ферм и арок', 'n:int;N:int', 122),
--5.5.5 Разрушение (повреждение) элементов связей ферм и арок
(278, 'Разрушение (повреждение) элементов крайней балки связей ферм и арок', 'n:int;N:int', 123),
--5.6 Узловые соединения (в соответствии с разделом 1.3.)
--5.6.1 Повреждение окрасочного слоя узловых соединений
(279, 'Повреждение окрасочного слоя узловых соединений', 'n:int;F:int', 124),
--5.6.2 Коррекция металла узловых соединений
(280, 'Коррекция металла узловых соединений', 'n:int;F:int', 125),
--5.6.3 Искривление фасонок узловых соединений
(281, 'Искривление фасонок узловых соединений', 'n:int;F:int', 126),
--5.6.4 Дефекты крепления раскосов к фасонкам узловых соединений
(282, 'Дефекты крепления раскосов к фасонкам узловых соединений', 'n:int;F:int', 127),
--6 Опорные части
--6.1 Прокладки
--6.1.1 Повреждение материала опорных частей
(283, 'Трещины и разрывы', 'n:int', 128),
(284, 'Расползание от чрезмерного сплющивания', 'n:int', 128),
(285, 'Недостаточная толщина', 'n:int', 128),
--6.1.2 Дефекты положения опорных частей
(286, 'Несоответствие требуемым осям опирания (смещения)', 'n:int;X:float;Y:float', 129),
(287, 'Развернуты в плане', 'n:int;ax:float;ay:float', 129),
(288, 'Плоскости балки и опорной площадки не параллельны', 'n:int;az:float', 129),
(289, 'Опирание не по всей плоскости', 'n:int;az:float', 129),
--6.1.3 Неверное применение опорных частей
(290, 'По величине линейных перемещений', 'n:int', 130),
(291, 'По величине угловых перемещений', 'n:int', 130),
(292, 'По величине опорной реакции', 'n:int', 130),
--6.2 РОЧ
--6.2.1 Повреждение материала РОЧ
(293, 'Трещины по боковым поверхностям', 'n:int', 131),
(294, 'Горизонтальные разрывы, расслоение опорных частей с оголением арматурных листов', 'n:int', 131),
--6.2.2 Дефекты положения РОЧ
(295, 'Смещение опорных частей в плане (несоответствие осям опирания)', 'n:int;X:float;Y:float', 132),
(296, 'Опорные части развернуты в плане', 'n:int;ax:float;ay:float', 132),
(297, 'Плоскости балки и опорной площадки не параллельны', 'n:int;az:float', 132),
(298, 'Опирание не по всей плоскости', 'df:float', 132),
(299, 'Наличие посторонних предметов под РОЧ', 'Bl:bool', 132),
(300, 'Близкое расположение к краю', 'Bl:bool', 132),
--6.2.3 Неверное применение РОЧ
(301, 'По величине линейных перемещений', 'n:int', 133),
(302, 'По величине угловых перемещений', 'n:int', 133),
(303, 'По величине опорной реакции', 'n:int', 133),
--6.3 Скользящие и резино-фторопластовые опорные части
--6.3.1 Повреждение материала Скользящие и резино-фторопластовые опорные части
(304, 'Разрушение (отсутствие) охватываемого кожуха', 'n:int;F:float', 134),
(305, 'Выдавливание резины в зазор между крышкой и обойной', 'n:int;F:float', 134),
(306, 'Коррозия листа (поверхности) скольжения', 'n:int;F:float', 134),
(307, 'Разрушение уплотнительных колец', 'n:int;F:float', 134),
(308, 'Повреждение фторопласта', 'n:int;F:float', 134),
--6.3.2 Дефекты положения Скользящие и резино-фторопластовые опорные части
(309, 'Несоответствие требуемым осям опирания', 'n:int;F:float', 135),
(310, 'Развернуты в плане', 'n:int;F:float', 135),
(311, 'Близкое расположение к краю', 'n:int;F:float', 135),
(312, 'Опирание не по всей плоскости', 'n:int;F:float', 135),
--6.3.3 Неверное применение Скользящие и резино-фторопластовые опорные части
(313, 'По величине линейных перемещений', 'n:int', 136),
(314, 'По величине угловых перемещений', 'n:int', 136),
(315, 'По величине опорной реакции', 'n:int', 136),
--6.3.4 Повреждение конструкций ОЧ
(316, 'Загрязнение конструкций ОЧ', 'n:int', 137),
(317, 'Коррозия конструкций ОЧ', 'n:int', 137),
(318, 'Нарушение закрепления конструкций ОЧ', 'n:int', 137),
(319, 'Повреждение противоугонных планок конструкций ОЧ', 'n:int', 137),
--6.4 Валковые, катковые, шарнирные
--6.4.1 Повреждение материалов валковых, катковых, шарнирных
(320, 'Бетона валков', 'n:int;F:float', 138),
(321, 'Отсутствие смазки', 'n:int;F:float', 138),
(322, 'Поверхность качения (скольжения)', 'n:int;F:float', 138),
--6.4.2 Дефекты положения валковых, катковых, шарнирных
(323, 'Смещение осей опирания', 'n:int;X:float;Y:float', 139),
(324, 'Разворот в плане', 'n:int;X:float;Y:float', 139),
(325, 'Близкое расположение к краю', 'n:int;X:float;Y:float', 139),
(326, 'Опирание не по всей плоскости', 'n:int;X:float;Y:float', 139),
(327, 'Нарушение работоспособности катков (валков)', 'n:int;X:float;Y:float', 139),
--6.4.3 Неверное применение валковых, катковых, шарнирных
(328, 'Неверное применение валковых, катковых, шарнирных', 'n:int', 140),
--6.4.4 Повреждение конструкций валковых, катковых, шарнирных
(329, 'Повреждение конструкций валковых, катковых, шарнирных', 'n:int', 141),
--7 Дефекты элементов железобетонных опор
--7.1 Ригель (устои и промежуточные опоры)
--7.1.1 Дефекты поверхностей ригеля
(330, 'Дефекты поверхностей ригеля', '', 142),
(331, 'Протечки ригеля', 'F:float', 142),
(332, 'Выщелачивание ригеля', 'F:float', 142),
(333, 'Шелушение ригеля', 'F:float', 142),
(334, 'Раковины и сколы незначительной глубины ригеля', 'F:float;T:float', 142),
(335, 'Раковины и сколы ригеля', 'F:float;T:float', 142),
(336, 'Отсутствие или недостаточные уклоны поверхности ригеля', '', 142),
--7.1.2 Разрушение защитного слоя ригеля
(337, 'Разрушение защитного слоя ригеля', 'T:float;F:float', 143),
--7.1.3 Трещины ригеля
(338, 'Трещины ригеля', 'C:float;L:float', 144),
--7.1.4 Разрушение бетона ригеля
(339, 'Разрушение бетона ригеля', 'C:float;L:float', 145),
--7.1.5 Повреждение стыков ригеля
(340, 'Повреждение стыков ригеля', 'n:int;L:float', 146),
--7.1.6 Дефекты арматуры ригеля
(341, 'Дефекты арматуры ригеля', '', 147),
--7.1.7 Разрушение деталей ригеля
(342, 'Разрушение (повреждение) подферменников из-за отсутствия их армирования', 'n:int', 148),
(343, 'Отрыв открылков устоя', 'n:int', 148),
(344, 'Повреждение шкафной стенки', 'n:int', 148),
(345, 'Разрушение заборной стенки', 'n:int', 148),
--7.1.8 Деформации опор ригеля
(346, 'Наклоны опор в продольном направлении (вдоль оси моста)', 'X:float', 149),
(347, 'Наклоны опор в направлении вдоль оси опоры (поперечный крен)', 'Y:float', 149),
(348, 'Вертикальные деформации', 'Y:float', 149),
(349, 'Наклон ригеля опор (поворот)', '', 149),
(350, 'Упирание пролетных строений в шкафную стенку', '', 149),
(351, 'Взаимное упирание торцов балок', '', 149),
--7.1.9 Опирание опорных частей на ригель с эксцентриситетом относительно оси ригеля
(352, 'Опирание опорных частей на ригель с эксцентриситетом относительно оси ригеля', '', 150),
--7.2 Тело опор
--7.2.1 Дефекты поверхности тела опор
(353, 'Дефекты поверхности тела опор', 'F:float', 151),
--7.2.2 Разрушение защитного слоя тела опор
(354, 'Разрушение защитного слоя тела опор', '', 152),
--7.2.3 Трещины тела опор
(355, 'Трещины тела опор', 'C:float;L:float', 153),
--7.2.4 Разрушение бетона тела опор
(356, 'Разрушение бетона тела опор', 'F:float', 154),
--7.2.5 Разрушение стыков (касается опор-стенок, опор из контурных блоков)
(357, 'Разрушение стыков (касается опор-стенок, опор из контурных блоков)', 'n:int', 155),
--7.2.6 Дефекты арматуры тела опор
(358, 'Дефекты арматуры тела опор', '', 156),
--7.2.7 Разрушение деталей тела опор
(359, 'Повреждения (разрушение) ледорезных деталей', '', 157),
(360, 'Повреждение заделки стоек (столбов) в бетон', 'n:int', 157),
(361, 'Повреждение облицовки', 'n:int;L:float', 157),
--7.2.8 Деформации элементов (деталей) опор
(362, 'Односторонний наклон стоек промежуточных опор', 'X:float;Y:float', 158),
(363, 'Наклон стоек в разные стороны', '', 158),
--7.2.9 Опирание с эксцентриситетом
(364, 'Ригеля на стойки', 'X:float', 159),
(365, 'Стоек на фундамент', 'X:float', 159),
(366, 'Несовпадение оси опорных частей с осью опоры', 'X:float', 159),
--7.3 Фундамент
--7.3.1 Дефекты поверхности (горизонтальной и вертикальной)
(367, 'Дефекты поверхности (горизонтальной и вертикальной)', 'F:float', 160),
--7.3.2 Разрушение защитного слоя фундамента
(368, 'Разрушение защитного слоя фундамента', 'F:float', 161),
--7.3.3 Трещины фундамента
(369, 'Трещины не силового характера (см. п.1 п/р. 1.1.3)', 'C:float;l:float', 162),
(370, 'Трещины коррозии вдоль арматуры (см. п.5 п/р. 1.1.3)', 'C:float;l:float', 162),
(371, 'Вертикальные трещины по боковым поверхностям фундамента', 'C:float;l:float', 162),
(372, 'Вертикальные трещины, выходящие на тело опоры', 'C:float;l:float', 162),
(373, 'Вертикальные трещины, доходящие до ригеля опоры', 'C:float;l:float', 162),
--7.3.4 Разрушение бетона
(374, 'Одиночные места со значительными разрушениями массива бетона (в т.ч. большие сколы углов)', 'n:int;T:float;V:float', 163),
(375, 'Размораживание бетона (см. п.З п/р 1.1.4)', 'F:float', 163),
--8 Дефекты регуляционных сооружений, конусов и подходов
--8.1 Укрепление
--8.1.1 Повреждение железобетонного (бетонного) укрепления
(376, 'Дефекты поверхности укрепления', 'F:float', 164),
(377, 'Разрушение защитного слоя укрепления', '', 164),
(378, 'Трещины (п.п. 1.2.3 р. 1.1.3) укрепления', 'C:float;F:float;L:float', 164),
(379, 'Разрушение укрепления', 'F:float', 164),
(380, 'Повреждение стыков укрепления', 'L:float', 164),
(381, 'Просадка укрепления', 'F:float;T:float', 164),
(382, 'Смещение, сползание укрепления', 'F:float', 164),
--8.1.2 Повреждение щебеночных и грунтовых укреплений
(383, 'Повреждение решетки (деревянной, бетонной)', 'f:float;F:float', 165),
(384, 'Вытаптывание', 'F:float;V:float', 165),
(385, 'Полное разрушение укреплений (отсутствие их там, где они должны быть)', '', 165),
--8.1.3 Повреждение рисбермы (упора)
(386, 'Трещины рисбермы', 'C:float;L:float', 166),
(387, 'Наклоны (смещение верха) рисбермы', 'L:float;T:float', 166),
(388, 'Локальное разрушение (сколы) рисбермы', 'n:int;L:float;T:float', 166),
(389, 'Полное разрушение (обрушение, сползание) рисбермы', 'L:float;T:float', 166),
--8.2 Конуса
--8.2.1 Локальные промоины
(390, 'Начальная стадия (глубина до 20см)', 'T:float;n:int', 167),
(391, 'Более значительные промоины', 'T:float;n:int', 167),
--8.2.2 Повреждение верхней части конуса (откоса)
(392, 'Небольшой размыв обочины и откоса', 'F:float;T:float', 168),
(393, 'Просадки обочины', 'F:float;T:float', 168),
(394, 'Значительные просадки с размывом', 'F:float;T:float', 168),
--8.2.3 Разрушение (вынос грунта) конуса (откоса)
(395, 'Разрушение (вынос грунта) конуса (откоса)', 'F:float;T:float', 169),
--8.2.4 Подмыв основания дамбы (конуса, откоса)
(396, 'Подмыв основания дамбы (конуса, откоса)', 'T:float;L:float', 170),
--9 Дефекты элементов деревянных мостов
--9.1 Мостовое полотно
--9.1.1 Повреждение верхнего настила
(397, 'Загнивание', 'F:float', 171),
(398, 'Трещины и сколы (износ)', 'F:float', 171),
(399, 'Нарушение крепления досок;', 'F:float', 171),
(400, 'Перелом досок', 'F:float', 171),
--9.1.2 Повреждение нижнего настила
(401, 'Загнивание досок нижнего настила', '', 172),
(402, 'Нарушение крепления досок нижнего настила', '', 172),
(403, 'Перелом досок нижнего настила', '', 172),
--9.1.3 Повреждение поперечин
(404, 'Загнивание поперечин', 'L(F):float', 173),
(405, 'Трещины поперечин', 'L(F):float', 173),
(406, 'Разрушение в узлах поперечин', 'L(F):float', 173),
--9.1.4 Дефекты колесоотбоя
(407, 'Дефекты колесоотбоя', 'L:float', 174),
--9.1.5 Дефекты тротуаров
(408, 'Дефекты тротуаров', 'L:float', 175),
--9.1.6 Дефекты перил (поручни, стойки, подкосы, заполнение)
(409, 'Дефекты перил (поручни, стойки, подкосы, заполнение)', 'L:float', 176),
--9.2 Пролетные строения
--9.2.1 Загнивание прогона по длине
(410, 'Загнивание прогона по длине', 'N:int;A:float', 177),
--9.2.2 Трещины в прогонах
(411, 'Трещины в прогонах', 'N:int;A:float', 178),
--9.2.3 Повреждение прогонов в узлах опирания и в зоне нагелей
(412, 'Повреждение прогонов в узлах опирания и в зоне нагелей', 'N:int;A:float', 179),
--9.2.4 Повреждение нагелей (шпонок)
(413, 'Наличие зазоров нагелей', 'N:int', 180),
(414, 'Трещины нагелей', 'N:int', 180),
(415, 'Разрушение нагелей', 'N:int', 180),
--9.2.5 Дефекты в балках с клееной древесиной
(416, 'Дефекты досок в балках с клееной древесиной', '', 181),
(417, 'Дефекты клеевых швов в балках с клееной древесиной', 'l:float', 181),
(418, 'Некачественная пропитка (отсутствие пропитки) в балках с клееной древесиной', 'l:float', 181),
(419, 'Повреждение поперечных связей в балках с клееной древесиной', '', 181),
(420, 'Сколы зубчатых соединений в стыках досок в балках с клееной древесиной', 'N:int', 181),
--9.3 Опоры
--9.3.1 Загнивание опор
(421, 'Загнивание опор', 'L:float;T:float', 182),
--9.3.2 Трещины опор
(422, 'Трещины опор', 'N:int', 183),
--9.3.3 Разрушение опор
(423, 'Разрушение опор', 'n:int', 184),
--9.3.4 Дефекты стыков и соединений (прикреплений)
(424, 'Неплотности в соединениях', 'N:int', 185),
(425, 'Повреждение древесины (загнивание, трещины, разрушения)', 'N:int', 185),
(426, 'Ослабление, повреждение крепежных деталей (хомутов, болтов, тяжей, скоб)', 'N:int', 185),
(427, 'Коррозия крепежных деталей;', 'N:int', 185),
(428, 'Разрушение (отсутствие) крепежных деталей', 'N:int', 185),
--9.3.5 Повреждение заборной стенки устоя (загнивание, трещины, разрушения)
(429, 'Повреждение заборной стенки устоя (загнивание, трещины, разрушения)', 'F:float', 186),
--9.3.6 Деформации опор (наклон вдоль и поперек, просадки или выпучивание)
(430, 'Деформации опор (наклон вдоль и поперек, просадки или выпучивание)', 'X:float;Y:float', 187),
--10 Дефекты подмостового пространства
--10.1 Несоответствие подмосгового габарита навигационным требованиям
(431, 'Несоответствие подмосгового габарита навигационным требованиям', 'S:float', 188),
--10.2 Несоответствие подмосгового габарита путепровода требованиям категории дороги под ним
(432, 'Несоответствие подмосгового габарита путепровода требованиям категории дороги под ним', 'S:float', 189),
--10.3 Стеснение русла посторонними предметами, корчей
(433, 'Стеснение русла посторонними предметами, корчей', 'N:int', 190),
--10.4 Нарушение укрепления русла
(434, 'Нарушение укрепления русла', 'F:float', 191),
--10.5 Размыв берегов
(435, 'Размыв берегов', 'F:float;T:float', 192),
--10.6 Разрушение укрепления берегов русла
(436, 'Разрушение укрепления берегов русла', 'F:float', 193),
--10.7 Зарастание подмосговой зоны на пойме и русле кустарниковой или древесной растительностью
(437, 'Зарастание подмосговой зоны на пойме и русле кустарниковой или древесной растительностью', 'N:int', 194),
--10.8 Повреждение навигационных знаков на мосту
(438, 'Повреждение навигационных знаков на мосту', 'n:int', 195),
--10.9 Нарушение дорожного полотна под сооружением
(439, 'Нарушение дорожного полотна под сооружением', '', 196),
--10.10 Нарушение системы водоотвода под мостовым сооружением
(440, 'Нарушение системы водоотвода под мостовым сооружением', '', 197),
--10.11 Повреждение соответствующих дорожных знаков и разметки в зоне путепровода на дороге
(441, 'Повреждение соответствующих дорожных знаков и разметки в зоне путепровода на дороге', '', 198),
--10.12 Нет щитов над контактным проводом
(442, 'Нет щитов над контактным проводом', 'n:int', 199),
--10.13 Нет или повреждены лестничные сходы
(443, 'Нет или повреждены лестничные сходы', 'n:int', 200)