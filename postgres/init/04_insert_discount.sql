--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3
-- Dumped by pg_dump version 14.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: discount; Type: TABLE DATA; Schema: ropuszka; Owner: postgres
--

INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (1, 'amet', 0.180, '2022-12-26', '2023-01-21');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (2, 'sint', 0.740, '2019-09-24', '2019-09-29');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (3, 'minus', 0.730, '2022-11-25', '2022-12-05');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (4, 'repellendus', 0.480, '2020-01-22', '2020-02-01');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (5, 'minus', 0.220, '2019-09-29', '2019-09-30');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (6, 'voluptatem', 0.060, '2019-06-15', '2019-06-18');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (7, 'sunt', 0.760, '2021-07-07', '2021-07-15');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (8, 'cum', 0.590, '2020-02-17', '2020-03-17');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (9, 'sit', 0.100, '2021-11-24', '2021-12-20');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (10, 'excepturi', 0.660, '2020-05-04', '2020-05-07');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (11, 'debitis', 0.970, '2019-09-08', '2019-09-17');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (12, 'vero', 0.490, '2020-07-15', '2020-08-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (13, 'quia', 0.540, '2020-03-07', '2020-03-14');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (14, 'et', 0.000, '2021-04-01', '2021-04-05');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (15, 'quasi', 0.910, '2020-01-19', '2020-02-11');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (16, 'quia', 0.920, '2020-11-28', '2020-12-03');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (17, 'qui', 0.020, '2020-03-18', '2020-04-08');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (18, 'omnis', 0.410, '2022-03-29', '2022-03-31');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (19, 'rerum', 0.100, '2019-07-05', '2019-07-11');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (20, 'rerum', 0.810, '2019-11-17', '2019-11-20');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (21, 'eum', 0.690, '2019-03-08', '2019-03-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (22, 'ullam', 0.070, '2019-03-11', '2019-03-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (23, 'provident', 0.590, '2022-02-18', '2022-03-08');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (24, 'voluptate', 0.580, '2022-11-08', '2022-12-07');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (25, 'quas', 0.030, '2022-05-12', '2022-06-07');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (26, 'amet', 0.690, '2019-09-06', '2019-09-30');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (27, 'id', 0.230, '2020-04-20', '2020-05-15');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (28, 'officiis', 0.390, '2019-12-17', '2019-12-25');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (29, 'cumque', 0.180, '2020-06-16', '2020-06-29');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (30, 'aut', 0.340, '2022-05-10', '2022-05-22');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (31, 'aut', 0.280, '2019-08-18', '2019-08-23');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (32, 'fuga', 0.220, '2021-08-18', '2021-08-27');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (33, 'dolores', 0.180, '2021-08-30', '2021-09-25');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (34, 'reiciendis', 0.380, '2022-07-27', '2022-08-17');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (35, 'non', 0.240, '2020-07-28', '2020-07-31');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (36, 'maxime', 0.240, '2019-07-28', '2019-08-02');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (37, 'ea', 0.530, '2022-07-27', '2022-08-03');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (38, 'modi', 0.530, '2019-04-07', '2019-04-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (39, 'adipisci', 0.460, '2022-06-10', '2022-07-08');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (40, 'sed', 0.010, '2019-09-11', '2019-09-27');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (41, 'sunt', 0.030, '2021-09-02', '2021-09-23');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (42, 'qui', 0.380, '2020-02-02', '2020-02-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (43, 'quis', 0.670, '2022-08-01', '2022-08-21');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (44, 'tenetur', 0.760, '2021-07-13', '2021-08-04');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (45, 'qui', 0.020, '2022-03-23', '2022-03-26');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (46, 'voluptas', 0.430, '2019-04-20', '2019-05-08');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (47, 'aut', 0.510, '2021-08-24', '2021-09-09');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (48, 'cupiditate', 0.980, '2019-08-12', '2019-08-28');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (49, 'architecto', 0.870, '2020-12-22', '2021-01-13');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (50, 'in', 0.440, '2020-08-25', '2020-09-24');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (51, 'quaerat', 0.570, '2022-09-27', '2022-10-14');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (52, 'facilis', 0.430, '2019-10-20', '2019-11-02');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (53, 'dolorem', 0.130, '2022-01-14', '2022-01-30');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (54, 'velit', 0.080, '2019-10-08', '2019-10-13');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (55, 'tenetur', 0.070, '2021-05-02', '2021-05-09');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (56, 'est', 0.750, '2022-03-04', '2022-03-13');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (57, 'occaecati', 0.370, '2021-04-03', '2021-04-06');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (58, 'minima', 0.910, '2019-08-17', '2019-09-07');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (59, 'id', 0.830, '2022-05-02', '2022-05-25');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (60, 'et', 0.520, '2022-10-23', '2022-11-13');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (61, 'enim', 0.240, '2021-10-07', '2021-10-19');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (62, 'incidunt', 0.630, '2020-04-13', '2020-05-13');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (63, 'nobis', 0.350, '2022-01-23', '2022-02-08');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (64, 'eos', 0.190, '2019-12-29', '2020-01-14');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (65, 'repellendus', 0.630, '2019-02-08', '2019-02-17');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (66, 'et', 0.120, '2019-07-29', '2019-08-26');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (67, 'aut', 0.060, '2022-08-28', '2022-09-08');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (68, 'dolore', 0.440, '2021-07-25', '2021-08-07');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (69, 'sed', 0.890, '2022-08-17', '2022-09-01');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (70, 'veritatis', 0.400, '2019-04-09', '2019-05-06');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (71, 'illo', 0.570, '2020-08-01', '2020-08-29');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (72, 'voluptatem', 0.650, '2022-05-02', '2022-05-15');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (73, 'qui', 0.320, '2022-11-08', '2022-12-04');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (74, 'et', 0.680, '2022-04-08', '2022-04-14');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (75, 'aspernatur', 0.770, '2020-09-06', '2020-09-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (76, 'quisquam', 0.950, '2021-12-25', '2022-01-02');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (77, 'quo', 0.340, '2020-07-16', '2020-08-14');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (78, 'quis', 0.760, '2020-10-13', '2020-10-25');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (79, 'similique', 0.140, '2019-11-09', '2019-11-18');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (80, 'est', 0.220, '2022-01-19', '2022-01-29');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (81, 'incidunt', 0.500, '2022-02-12', '2022-03-12');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (82, 'deleniti', 0.770, '2022-09-11', '2022-09-25');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (83, 'vitae', 0.710, '2020-07-18', '2020-07-27');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (84, 'reiciendis', 0.890, '2019-09-03', '2019-09-06');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (85, 'dolorem', 0.160, '2019-11-04', '2019-11-29');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (86, 'ut', 0.860, '2019-06-26', '2019-07-21');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (87, 'aut', 0.570, '2020-03-03', '2020-03-14');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (88, 'rem', 0.520, '2020-11-08', '2020-12-05');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (89, 'sit', 0.100, '2022-10-02', '2022-10-09');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (90, 'quia', 0.820, '2022-01-12', '2022-02-09');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (91, 'esse', 0.940, '2022-07-03', '2022-07-21');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (92, 'vel', 0.160, '2020-08-13', '2020-09-03');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (93, 'ut', 0.110, '2020-11-16', '2020-12-04');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (94, 'aut', 0.950, '2019-03-18', '2019-03-29');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (95, 'eum', 0.950, '2019-02-27', '2019-03-26');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (96, 'corrupti', 0.560, '2022-11-06', '2022-11-23');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (97, 'aliquam', 0.510, '2020-01-22', '2020-02-18');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (98, 'sapiente', 0.950, '2022-09-10', '2022-10-10');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (99, 'in', 0.280, '2020-07-26', '2020-08-05');
INSERT INTO ropuszka.discount (id, name, percentage, date_from, date_to) VALUES (100, 'repellat', 0.550, '2020-10-07', '2020-10-29');


--
-- PostgreSQL database dump complete
--

