Feature: GetUserAuthority
	In order to 權限控管
	As a 線上使用者
	I want to 取得使用者權限
    
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
	And 回傳使用者BardyardID為 'jacktsai'
    And 回傳目標網址為 '/test.aspx'
    And 回傳讀取權限為 True
    And 回傳SELECT權限為 False
    And 回傳INSERT權限為 False
    And 回傳UPDATE權限為 False
    And 回傳DELETE權限為 False
    And 回傳特殊權限為 False
    
Scenario: 以 Backyard ID 'jacktsai' 取得 '/Security/Privilege/UserMgmt.aspx' 的操作權限
    Given BackyardID為 'jacktsai'
    And 目標網址為 '/Security/Privilege/UserMgmt.aspx'
	When 取得操作權限
    Then 回傳成功狀態
	And 回傳使用者BardyardID為 'jacktsai'
    And 回傳目標網址為 '/Security/Privilege/UserMgmt.aspx'
    And 回傳讀取權限為 True
    And 回傳SELECT權限為 True
    And 回傳INSERT權限為 True
    And 回傳UPDATE權限為 True
    And 回傳DELETE權限為 True
    And 回傳特殊權限為 True
    
Scenario: 以 Backyard ID 'jacktsai' 取得 'not_exists.aspx' 的操作權限
    Given BackyardID為 'jacktsai'
    And 目標網址為 'not_exists.aspx'
	When 取得操作權限
    Then 回傳成功狀態
	And 回傳使用者BardyardID為 'jacktsai'
    And 回傳目標網址為 'not_exists.aspx'
    And 回傳讀取權限為 False
    And 回傳SELECT權限為 False
    And 回傳INSERT權限為 False
    And 回傳UPDATE權限為 False
    And 回傳DELETE權限為 False
    And 回傳特殊權限為 False
    