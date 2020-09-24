# EasyCruitChallenge

Here are instructions for deploying on Azure and administration using AzureDevops.

You need to setup automatic deployment on Azure using this step. You will be prompted your Azure credentials and that is it.
![Pic1](https://i.imgur.com/0L1Rsn7.png)

After each commit, CI build will be run.
![Pic2](https://i.imgur.com/hXjbod6.png)

On successful build Azure auto deploys.
![Pic3](https://i.imgur.com/8OmPELW.png)

Email notification comes.
![Pic4](https://i.imgur.com/cUmyM0e.png)

Tests are run, if there are fails - build fails.
![Pic5](https://i.imgur.com/VYRWqmE.png)

To get a JS SPA working on Azure you need to additional build steps - npm install, npm build, and copy from js dist to output.
![Pic6](https://i.imgur.com/tgXxdI5.png)
