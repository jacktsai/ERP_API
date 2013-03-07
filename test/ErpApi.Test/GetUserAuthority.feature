Feature: GetUserAuthority
	In order to 權限控管
	As a 線上操作者
	I want to 取得操作者權限
    
Scenario: 以無 Backyard ID 取得操作權限
    Given 無BackyardID
    And 無目標網址
    When 取得操作權限
    Then 回傳狀態為 'BadRequest'
    
Scenario: 以空白 Backyard ID 取得操作權限
    Given BackyardID為空白
    And 目標網址為空白
    When 取得操作權限
    Then 回傳狀態為 'BadRequest'

Scenario: 以 Backyard ID 'jacktsai' 取得 '/test.aspx' 的操作權限
    Given BackyardID為 'jacktsai'
    And 目標網址為 '/test.aspx'
	When 取得操作權限
    Then 回傳成功狀態
	And 回傳操作者BardyardID為 'jacktsai'
    And 回傳目標網址為 '/test.aspx'
    And 回傳細部權限-SELECT為 True
    And 回傳細部權限-INSERT為 True
    And 回傳細部權限-UPDATE為 True
    And 回傳細部權限-DELETE為 True
    And 回傳細部權限-特殊權限為 True
    
Scenario: 以 Backyard ID 'jacktsai' 取得 '/Security/Privilege/UserMgmt.aspx' 的操作權限
    Given BackyardID為 'jacktsai'
    And 目標網址為 '/Security/Privilege/UserMgmt.aspx'
	When 取得操作權限
    Then 回傳成功狀態
	And 回傳操作者BardyardID為 'jacktsai'
    And 回傳目標網址為 '/Security/Privilege/UserMgmt.aspx'
    And 回傳細部權限-SELECT為 True
    And 回傳細部權限-INSERT為 True
    And 回傳細部權限-UPDATE為 True
    And 回傳細部權限-DELETE為 True
    And 回傳細部權限-特殊權限為 True
