CREATE DATABASE mercado;

USE mercado;

CREATE TABLE produtos (

codigo INT AUTO_INCREMENT PRIMARY KEY,

nome VARCHAR(100) NOT NULL,

preco DECIMAL(10,2) NOT NULL

);

INSERT INTO produtos (nome, preco) VALUES

('Suco', 5.50),

('Bola', 15.00),

('Refrigerante', 8.00),

('Arroz', 22.50),

('Feijão', 9.80);

SELECT * FROM produtos;