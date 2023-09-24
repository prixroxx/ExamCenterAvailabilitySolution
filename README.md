# ExamCenterAvailabilitySolution

This WebAPI contains a functionality to perform CRUD operations on two tables
- Availabilities
- ExamCenters

## Exam Centers

### Create Exam Center

The JSON to create a new Exam Center would be
```
{
    "name":"FamousExamCenter",
    "zipcode": "11111",
    "isActive": true
}
```
Once created it returns the Id.

:robot: `N.B. - zipcode is defined from a dictionary and can have only one of these five values right now - ["11111","22222","33333","12345","67890"]`

### Get All Exam Centers

This will be a GET HTTP request to path `api/ExamCenter`
Returns a list of all Exam Centers with their IDs.

### Get Exam Center By ID

To get an exam center's data make a GET call to path `api/ExamCente/{centerId:int}`
Returns Exam Center data for the given Id.

## Availability

### Create Available Slots

This will be a POST HTTP request to path `availability/Create`
The JSON to create a new Availability would be
```
{
    "examcenterid":3,
    "starttime":"2023-09-26T09:45:04.386958",
    "endtime":"2023-09-26T12:45:04.386958",
    "seatcount":150,
    "seatsleft":2,
    "isActive":true
}
```
Once an entry is created in DB, it returns the Id.

:robot: `N.B. - If seatsleft is 0 or isActive is set to false, availability slot won't show up for booking`

### Get All Availabilities

This will be a GET HTTP request to path `availability`
Returns a list of all Exam Centers with their IDs (_irrespective of their seat count remaining or isActive status_).

### Get Exam Centers Within a Region

This will be a POST HTTP request to path `availability`

The JSON to fetch all Available Slots at any exam centers within the `distanceInMiles` distance would be:
```
{
    "duration": 150,
    "zipcode":"22222",
    "distanceInMiles":200
}
```

Result would look something like:
```
[
    {
        "id": 4,
        "name": "FamousExamCenter",
        "address": "11111",
        "startTime": "2023-09-26T09:45:04.386958",
        "seats": 0,
        "latitude": 45.22738570006638,
        "longitude": -93.9960240952021,
        "distanceMiles": 43.862211920652854
    }
]
```
Behind the scenes, we are checking if the test centers within the stipulated miles radius have a seat within the available time slots for the given duration.

## Not Completed Yet

- Unit Testing.
- Delete (isActive False) functionality for Exam Centers and Availability Slots.
- Update Availability table to decrease seatsleft count by 1 for every booking.
- Create a new Booking and give Booking Details to User.


## Thank You! :tea:


