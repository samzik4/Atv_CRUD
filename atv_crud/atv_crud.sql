create database atv_crud;
use atv_crud;

CREATE TABLE Funcionario (
    id_func INT PRIMARY KEY AUTO_INCREMENT,
    nome_func VARCHAR(100),
    cpf_func VARCHAR(14)
);

insert into funcionario values (null, "eloizy", "000.000.000-00");
insert into funcionario values (null, "samuel", "000.000.000-00");
insert into funcionario values (null, "patrick", "000.000.000-00");
insert into funcionario values (null, "fabricio", "000.000.000-00");

select * from funcionario;

CREATE TABLE Caixa (
    id_cai INT PRIMARY KEY AUTO_INCREMENT,
    saldo_inicial_cai DOUBLE,
    total_entradas_cai DOUBLE,
    total_saidas_cai DOUBLE,
    status_cai VARCHAR(20),
    saldo_final_cai double,
    id_func_fk INT NOT NULL,
    FOREIGN KEY (id_func_fk)
        REFERENCES Funcionario (id_func)
);

select * from caixa;