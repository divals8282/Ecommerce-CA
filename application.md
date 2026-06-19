# This application created for educational purposes
### Application demonstrating "Clean Architecture" pattern in ecommerce platform

## APP GOAL - Ecommerce platform which are providing basic functionality of internet shop.

# Authentication - 'JWT' where 2 type of tokens 'Access' and 'Refresh' 
## Access - life time 15min payload contains userId and role
## Refresh - life time 1day payload empty, stored into relational database

# Role system - where 2 type of user 'content-manager' and 'client'
## content-manager - able to integrate new products into system with (CRUD)
## client - able to see list of products with pagination logic

# Card Feature - where even not registered and loggedIn user able to add products in-to card which are working with uniq identities with cookies
## Card attached to cookie which are should be provided into client(device) when client trying to add first product into card
## Should be integrated CRON job which are removing all passive card's, which are not been modified in last 7 days
## Also Card should be removed when user doing checkout, on that moment all card data should be archivated as history attached into "Client" user

# Checkout Feature - when card not empty and user(client) are loggedin, user able to do checkout which are archivating all card data and save it as history
## content-manager based on user able to see all checkouts of users
## client - able to see all own checkout history