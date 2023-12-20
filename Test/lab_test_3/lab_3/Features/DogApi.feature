Feature: Dogs API

Scenario: LIST ALL BREEDS
When I send a GET request to "https://dog.ceo/api/breeds/list/all"
Then the response status should "success"

Scenario: SINGLE RANDOM IMAGE
When I send a GET request to "https://dog.ceo/api/breeds/image/random"
And I get a reponce message 
Then the response status should "success"

Scenario: BY BREED
When I send a GET request to "https://dog.ceo/api/breed/hound/images"
And I get a reponce message 
Then the response status should "success"

Scenario: LIST ALL SUB-BREEDS
When I send a GET request to "https://dog.ceo/api/breed/hound/list"
And I get a reponce message 
Then the response status should "success"

Scenario: BREEDS LIST
When I send a GET request to "https://dog.ceo/api/breed/hound/afghan/images/random/3"
And I get a reponce message 
Then the response status should "success"