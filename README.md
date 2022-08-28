# YouTube Wrapper
A Youtube Wrapper that caches results based on specific keywords which uses (.NET) Core as Backend & MongoDB as Database.

Following are the Software Required to run the Application in local : 
### 1. Visual Studio  (https://visualstudio.microsoft.com/)
### 2. MongoDB (https://www.mongodb.com/try/download/community)
### 3. Postman* : To Test API (https://www.postman.com/downloads/)
*Not Mandatory

## Steps : -

#### 1. Open MongoDB Compass / CLI(make sure it is running on port number27017 which is the default port) and create database YoutubeCache with collection name Videos.
#### 2. Create a Folder where you want to clone the project.
#### 3. Open Powershell in that folder and run command ```git clone https://github.com/SubhanshuB/YouTubeWrapper.git``` OR If you don't have git install you can directly download(https://github.com/SubhanshuB/YouTubeWrapper/archive/refs/heads/master.zip) the zip file and extract it in this folder.
#### 4. Open API folder then  open Visual Studio Solution(.sln) file in Visual Studio.
#### 5. Once opened, run the project in IIS Server.
#### 7. Use Postman or any other API Client to test the API.
#### 8. Below is the curl Request, which you can copy and import in postman for faster execution :  
curl --location --request GET 'https://localhost:44371/Youtube?queryCount=5&searchQuery=python'

This request has 2 optional parameters :

#### queryCount : This takes integer as input and return the same number of records(Pagination), its default value is 5.

#### searchQuery : This takes string as input and is used to search is the cached data, you can add keywords or enitre sentence it takes care of all.

DONE!

Below are the screenshots: 
### .NET Core Backend
![Screenshot (96)](https://user-images.githubusercontent.com/30664033/187084572-c6131ed5-63be-4e3b-bb04-88e487d079ad.png)
### MongoDb
![Screenshot (97)](https://user-images.githubusercontent.com/30664033/187084581-1ecd48db-4264-477b-bac6-0ddebd1388fc.png)
# Thank You!
