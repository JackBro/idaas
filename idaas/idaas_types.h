/**
 * Autogenerated by Thrift Compiler (0.9.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
#ifndef idaas_TYPES_H
#define idaas_TYPES_H

#include <thrift/Thrift.h>
#include <thrift/TApplicationException.h>
#include <thrift/protocol/TProtocol.h>
#include <thrift/transport/TTransport.h>



namespace idaas {

typedef struct _ida_enum__isset {
  _ida_enum__isset() : id(false), name(false), isBitfield(false) {}
  bool id;
  bool name;
  bool isBitfield;
} _ida_enum__isset;

class ida_enum {
 public:

  static const char* ascii_fingerprint; // = "7E2C98E75504E1229F703BD18FE1300F";
  static const uint8_t binary_fingerprint[16]; // = {0x7E,0x2C,0x98,0xE7,0x55,0x04,0xE1,0x22,0x9F,0x70,0x3B,0xD1,0x8F,0xE1,0x30,0x0F};

  ida_enum() : id(0), name(), isBitfield(0) {
  }

  virtual ~ida_enum() throw() {}

  int32_t id;
  std::string name;
  bool isBitfield;

  _ida_enum__isset __isset;

  void __set_id(const int32_t val) {
    id = val;
  }

  void __set_name(const std::string& val) {
    name = val;
  }

  void __set_isBitfield(const bool val) {
    isBitfield = val;
  }

  bool operator == (const ida_enum & rhs) const
  {
    if (!(id == rhs.id))
      return false;
    if (!(name == rhs.name))
      return false;
    if (!(isBitfield == rhs.isBitfield))
      return false;
    return true;
  }
  bool operator != (const ida_enum &rhs) const {
    return !(*this == rhs);
  }

  bool operator < (const ida_enum & ) const;

  uint32_t read(::apache::thrift::protocol::TProtocol* iprot);
  uint32_t write(::apache::thrift::protocol::TProtocol* oprot) const;

};

void swap(ida_enum &a, ida_enum &b);

typedef struct _ida_enum_const__isset {
  _ida_enum_const__isset() : id(false), name(false), value(false), serial(false), mask(false) {}
  bool id;
  bool name;
  bool value;
  bool serial;
  bool mask;
} _ida_enum_const__isset;

class ida_enum_const {
 public:

  static const char* ascii_fingerprint; // = "4DC061E99100674CECF319144EC27B22";
  static const uint8_t binary_fingerprint[16]; // = {0x4D,0xC0,0x61,0xE9,0x91,0x00,0x67,0x4C,0xEC,0xF3,0x19,0x14,0x4E,0xC2,0x7B,0x22};

  ida_enum_const() : id(0), name(), value(0), serial(0), mask(0) {
  }

  virtual ~ida_enum_const() throw() {}

  int32_t id;
  std::string name;
  int32_t value;
  int8_t serial;
  bool mask;

  _ida_enum_const__isset __isset;

  void __set_id(const int32_t val) {
    id = val;
  }

  void __set_name(const std::string& val) {
    name = val;
  }

  void __set_value(const int32_t val) {
    value = val;
  }

  void __set_serial(const int8_t val) {
    serial = val;
  }

  void __set_mask(const bool val) {
    mask = val;
  }

  bool operator == (const ida_enum_const & rhs) const
  {
    if (!(id == rhs.id))
      return false;
    if (!(name == rhs.name))
      return false;
    if (!(value == rhs.value))
      return false;
    if (!(serial == rhs.serial))
      return false;
    if (!(mask == rhs.mask))
      return false;
    return true;
  }
  bool operator != (const ida_enum_const &rhs) const {
    return !(*this == rhs);
  }

  bool operator < (const ida_enum_const & ) const;

  uint32_t read(::apache::thrift::protocol::TProtocol* iprot);
  uint32_t write(::apache::thrift::protocol::TProtocol* oprot) const;

};

void swap(ida_enum_const &a, ida_enum_const &b);

} // namespace

#endif
