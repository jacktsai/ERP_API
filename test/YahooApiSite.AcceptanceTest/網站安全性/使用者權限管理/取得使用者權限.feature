Feature: 取得使用者權限
	In order to 權限控管
	As a 線上使用者
	I want to 取得我能用的功能清單

@HttpClient
Scenario: 取得使用者 2733 的權限
	When 以使用者編號 2733 取得權限清單
	Then 回傳使用者編號為 2733
    And 回傳清單筆數為 259
    And 包含功能編號 148
    And 包含功能編號 695
    And 包含功能編號 801
    And 包含功能編號 890
    And 包含功能編號 1069
    And 包含功能編號 1228
    And 包含功能編號 1282