Feature: WishList
	In order to test the wish list funciotnality of bunnings website
	visit bunnings website and select one prouect 
	the product should be added successfully

@mytag
Scenario: Wish list
	Given Visit the bunnings website 
	When  sercah term "paint"
	When   Randomly visit one prouect from Seearch result and click on add to wish list
	Then  The prouect should be added successfully
