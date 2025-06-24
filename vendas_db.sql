

CREATE DATABASE vendas_db;
        
USE vendas_db;
CREATE TABLE produtos (
codigo INT PRIMARY KEY,
nome VARCHAR(100) NOT NULL,
preco DECIMAL(10,2) NOT NULL
);
                    
           
                                  

               
CREATE TABLE vendas (
id INT AUTO_INCREMENT PRIMARY KEY,
data DATETIME NOT NULL,
total DECIMAL(10,2) NOT NULL,
valor_pago DECIMAL(10,2) NOT NULL,
troco DECIMAL(10,2) NOT NULL
);
                        
                        
                        
CREATE TABLE itens_venda (
id INT AUTO_INCREMENT PRIMARY KEY,
venda_id INT NOT NULL,
produto_codigo INT NOT NULL,
quantidade INT NOT NULL,
preco_unitario DECIMAL(10,2) NOT NULL,
FOREIGN KEY (venda_id) REFERENCES vendas(id)
);
                        
INSERT INTO produtos (codigo, nome, preco) VALUES 
(1, 'Produto A', 10.50),
(2, 'Produto B', 25.00),
(3, 'Produto C', 7.80);