Feature: TestTask

@test
Scenario: Open 'phptravels' and verify invoice data
	Given Open phptravels site and login
	Then Try to find hotel
	| Hotel                         |
	| Hurghada Sunset Desert Safari |
	When Open write review popup dialog
	| Hotel                         |
	| Hurghada Sunset Desert Safari |
	When Configure parameters on review popup 
	| clean | staff |
	| 10    | 2     |
	When the write review message and close dialog
	| Message                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
	| Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. |
	When Open invoice from 'Hurghada Sunset Desert Safari' hotel
	Then verify deposit information
	| DEPOSIT NOW | TAX & VAT | TOTAL AMOUNT |
	| USD $30.80  | USD $28   | USD $308     |
	