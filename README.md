
# Ziique Social

Ziique Social is a social platform that is entirily selfhosted.
This project was made for an exam about security. Hense will no longer be maintained after.

## Features
- Be able to see public post as a guest
- Create your own account
- Make post on a global dashboard
- Make post private, public or only visible to people you follow.
- Go to people profiles and only see thier post
- Follow people you like


## Setup of frontend

### Requirements
- Node installed
- A browser

### Steps
#### Step 1:
Clone the repository.
#### Step 2:
navigate to the folder called ZiiqueFrontend
#### Step 3:
open a command prompt and paste in ```npm install```
#### Step 4:
After all node modules have been installed you can run the frontend with ```npm run dev```

## Setup of Backend

### Requirements
- Docker
- Free ports at 8090, 8080, and 5432

### First Step: Ensure the Placement of the .env File
1. Download the `docker_secrets.env` file from the appendix of our report.
2. Place it within the project at `ZiiqueSocial/backend`.

### Running the Images
1. Navigate to `ZiiqueSocial/backend`.
2. Run the following command in a terminal:

```docker compose up -d```                  
Verify that all containers have started.

Setting Up Keycloak
Download ziique-export.json from the appendix.

In a browser, go to http://localhost:8080/.

Log in with the credentials from docker_secrets.env:


KEYCLOAK_ADMIN=                                    
KEYCLOAK_ADMIN_PASSWORD=                              
After logging in, in the top left corner, press the "Keycloak master" button and then press "Create realm".

Drag the ziique-export.json file into the big white field and make sure "Enabled" is set to "On".

You are now ready to use the frontend.
