# E-commerce

In this exercise we will manage an e-commerce system. We will save the name of the system as well as information about the buyers and
the sellers. For each user we will save his username, login password and residential address
(Address is the street name, building number, city and country). Each user is either a seller or a buyer (none
Someone who is both a seller and a buyer).
For each seller, all the products he sells must be kept for him.
No need to manage inventory. For each buyer we will keep the shopping cart containing the products
that the customer has chosen and not yet ordered. Each product is associated with a certain category (children, electricity, office and clothing),
It has a name, and a price. There are products that require special packaging, then you have to save for them
Also the additional price for the exhibit for the packaging. When a customer places an order, he orders all
The products from his product cart. For the order we will keep the product items, the order price
including, and the buyer's details. When paying for the order, the cart items will be added to the history
the orders and it will be possible to fill a new cart. For each buyer, you can view their order history
And in the current cart. 
Each product will have an automatic serial number.
 We will add the option for the seller to sell products with special packaging as well as in the purchase of these products by
The buyer (note that the menu should not change as a result)
 For each product, in addition to its name and price, we will save the category to which it belongs.
 It must be supported that this time the input will not necessarily be of the requested type, in which case a message must be displayed
appropriate and ask for the input again.
 If a customer wishes to place an order for a cart with only one item, this will not be possible and will be discarded
An exception that will be handled with an appropriate message in Main
 Use the operator + which adds a buyer to the system, and a version that adds a seller to the system
 Implement the < operator which compares two buyers based on the amount of their current shopping cart.
Added an option in the menu to check this add-on.
 Added the option of creating a new cart from one of the carts in the user's history
 We updated that the display of sellers in the menu will be sorted by the number of items they sell.
Upon exiting the program, save the entire list of sellers and their products to a file and upon uploading
The system loaded these data.
