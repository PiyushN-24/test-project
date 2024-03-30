pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                // Checkout the code from Git repository
                checkout scm
            }
        }
        stage('Build') {
            steps {
                // Run MSBuild commands to build the .NET MVC project
                // sh 'msbuild /p:Configuration=Release Task_Mvc.csproj'
		sh 'dotnet build'
            }
        }
        stage('Deploy') {
            steps {
                // Deploy based on branch name
                script {
                    if (env.BRANCH_NAME == 'master') {
                        sh 'mkdir -p /path/to/Production'
                        sh 'cp -r build/* /path/to/Production'
                    } else if (env.BRANCH_NAME == 'development') {
                        sh 'mkdir -p /path/to/Development'
                        sh 'cp -r build/* /path/to/Development'
                    } else {
                        echo "No deployment needed for branch ${env.BRANCH_NAME}"
                    }
                }
            }
        }
    }
    
    post {
        // Notify stakeholders in case of build failures
        failure {
            emailext subject: "Build failed for ${env.JOB_NAME}",
                      body: "Build failed on branch ${env.BRANCH_NAME}.",
                      to: "piyushnawghare609@gmail.com"
        }
    }
}
