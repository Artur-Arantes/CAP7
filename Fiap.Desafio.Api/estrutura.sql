CREATE TABLE person (
                        person_name VARCHAR(255) NOT NULL,
                        email VARCHAR(255) PRIMARY KEY
);
CREATE TABLE if not exists permission (
                                          id_permission Bigint(20) auto_increment PRIMARY KEY,
    permission_name VARCHAR(255) NOT NULL
    );

CREATE TABLE users (
                       id_user BigInt(20) auto_increment PRIMARY KEY,
                       login VARCHAR(50) NOT NULL,
                       passwords VARCHAR(255) NOT NULL,
                       id_person VARCHAR(255) NOT NULL,
                       enabled tinyint(1) NOT NULL,
                       user_role VARCHAR(50) DEFAULT 'USER',
                       send_notification BigInt(1) DEFAULT 0,
                       FOREIGN KEY (id_person) REFERENCES person(email)
);

CREATE TABLE user_permission (
                                 id_permission bigint(20) NOT NULL,
                                 id_user bigint(20) NOT NULL,
                                 PRIMARY KEY (id_permission, id_user),
                                 FOREIGN KEY (id_permission) REFERENCES permission(id_permission),
                                 FOREIGN KEY (id_user) REFERENCES users(id_user)
);

CREATE TABLE resources (
                           id_resource bigint(20) auto_increment PRIMARY KEY,
                           resource_name VARCHAR(100),
                           unity_measure VARCHAR(50)
);

CREATE TABLE resource_index (
                                id_resource bigint(20) PRIMARY KEY,
                                ind_minimum Integer,
                                ind_normal Integer,
                                ind_maximum Integer,
                                FOREIGN KEY (id_resource) REFERENCES resources(id_resource)
);

CREATE TABLE record_measurements (
                                     id_record bigint(20) PRIMARY KEY auto_increment,
                                     id_resource bigint(20) NOT NULL,
                                     date_time Varchar(255),
                                     measure Integer,
                                     location VARCHAR(200),
                                     FOREIGN KEY (id_resource) REFERENCES resources(id_resource)
);

CREATE TABLE alert_status (
                              id_alert bigint(20) PRIMARY KEY,
                              id_record bigint(20) NOT NULL,
                              alert_description VARCHAR(500),
                              date_time_alert TIMESTAMP,
                              send_notication tinyint(1),
                              alert_status VARCHAR(50),
                              FOREIGN KEY (id_record) REFERENCES record_measurements(id_record)
);

CREATE TABLE notification_users (
                                    id_user bigint(20) NOT NULL,
                                    id_alert bigint(20) NOT NULL,
                                    PRIMARY KEY (id_alert, id_user),
                                    FOREIGN KEY (id_alert) REFERENCES alert_status(id_alert),
                                    FOREIGN KEY (id_user) REFERENCES users(id_user)
);

insert into permission values(1,"user");
insert into resources values (1,'agua', 'qualquer_medida');
insert into resource_index VALUES(1,50,20,30);
insert into person VALUES('fiap', 'fiap@teste.com');
insert into users VALUES(9999,'fiap','3333','fiap@teste.com',1,'user',0);
