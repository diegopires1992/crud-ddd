Para clonar um projeto do GitHub para a sua máquina local, siga estas instruções passo a passo:
Abra o terminal:

No Windows, você pode usar o PowerShell ou o Git Bash.
No MacOS ou Linux, você pode usar o Terminal.

Navegue até o diretório onde deseja clonar o projeto:
Use o comando cd (change directory) para navegar até o local desejado. Por exemplo:
cd caminho/do/diretorio

Obtenha o URL do repositório no GitHub:
No GitHub, vá para o repositório que deseja clonar e clique no botão "Code". Certifique-se de que o URL que você copiará seja do tipo "HTTPS" ou "SSH".

Clone o repositório:
  Se estiver usando SSH (requer que você tenha configurado as chaves SSH), use este comando:
    git clone git@github.com:diegopires1992/crud-ddd.git

Aguarde o término do processo de clonagem:
Depois de executar o comando git clone, o Git começará a baixar todos os arquivos do repositório para o diretório atual.

Para instalar e configurar o Docker Desktop em sua máquina, siga estas instruções:

Baixe o Docker Desktop:
Acesse o site oficial do Docker Desktop e baixe o instalador para o seu sistema operacional (Windows ou macOS): Docker Desktop.

Instale o Docker Desktop:
Execute o instalador baixado e siga as instruções do assistente de instalação.

Verifique a instalação:
Abra o terminal (PowerShell no Windows, Terminal no macOS) e execute o seguinte comando para verificar se o Docker está instalado corretamente:

docker --version

Agora que temos o Docker instalado podemos executar o docker compose para iniciar o banco de dados sqlserver:
![docker](https://github.com/diegopires1992/crud-ddd/assets/66563440/293e90b4-cc50-431c-97f9-e7f46a5c8fc1)

Agora executar o comando para fazer o migração para banco:
![migrations](https://github.com/diegopires1992/crud-ddd/assets/66563440/ea61921f-5c2d-4567-ac8c-af8a5a17b905)

Depois disso vamos usar o visual studio para executar:
![start](https://github.com/diegopires1992/crud-ddd/assets/66563440/99a3450f-8b12-4c62-89ce-288fa2dae780)


