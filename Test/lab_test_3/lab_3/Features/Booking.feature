Feature: Booking

@Get
  Scenario: Get
    When I send a GET request to "https://restful-booker.herokuapp.com/booking"
    Then the response status code should OK





@Put
Scenario Outline: Put
    When I send a POST request to "https://restful-booker.herokuapp.com/auth" with details "admin" and "password123"
    And I create a booking with id:<booking_id>
    And I send a PUT request to "https://restful-booker.herokuapp.com/booking/:id" with this booking
    Then the response status code should OK
    Examples:
    | booking_id |
    | 505       |

@Delete
Scenario Outline: Delete
    When I send a POST request to "https://restful-booker.herokuapp.com/auth" with details "admin" and "password123"
    And I send a Delete request to "https://restful-booker.herokuapp.com/booking/:id" with a booking id:<booking_id>
    Then the response status code should be COMPLETED
    Examples: 
    | booking_id |
    | 208        |

@POST
Scenario Outline: CreateBooking
    Given Booking with details:<totalprice>,<depositpaidcheckin>,<checkin>,<checkout>,<firstname>,<lastname>
    When I send a POST request to "https://restful-booker.herokuapp.com/booking" with selected booking details
    Then the response status code should OK
    Examples: 
    | firstname | lastname | totalprice | depositpaidcheckin | checkin    | checkout   |
    | Olga      | Petrova  | 150        | True               | 2022-03-15 | 2022-03-20 |
    | Ivan      | Ivanov   | 180        | False              | 2022-04-10 | 2022-04-15 |

